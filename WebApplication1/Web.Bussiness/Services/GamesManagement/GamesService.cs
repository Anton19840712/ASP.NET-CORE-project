using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Web.Bussiness.DTOs;
using Web.Bussiness.Models.CommonModels;
using Web.Bussiness.Models.UserModels;
using Web.Bussiness.Services.CommonManagement.ProductManagement;
using Web.DAL.Enums;
using Web.DAL.Models;

namespace Web.Bussiness.Services.GamesManagement
{
    public class GamesService : IDataManipulationGameService, IObjectsManipulationGamesService
    {
        #region Private fields

        private readonly AppIdentityDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IS3Service _iS3Service;

        #endregion

        #region Constructor

        public GamesService(AppIdentityDbContext context, IConfiguration configuration, IS3Service iS3Service)
        {
            _context = context;
            _configuration = configuration;
            _iS3Service = iS3Service;
        }

        #endregion

        #region Service methods

        public async Task<List<string>> GetTopThreeCategoriesByQuantity()
        {
            return await (_context.Products
                .OrderByDescending(x => x.DateCreated)
                .GroupBy(p => p.Category)
                .Select(g => new {Name = g.Key, Count = g.Count()})
                .OrderByDescending(x => x.Count)
                .Take(3)
                .Select(element => element.Name.ToString())
                .ToListAsync());
        }

        public Task<List<Product>> FilterProductsByTermWithLimitNumber(string term, int limit)
        {
            return _context.Products.Where(s => s.Name.Contains(term)).Take(limit).ToListAsync();
        }

        public async Task<ProductDto> FindProductById(int productDtoId)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == productDtoId);
            var uiProduct = result.Adapt<ProductDto>();
            return uiProduct;
        }

        public async Task<ProductDto> CreateNewProduct(ProductDto productDto)
        {
            var databaseProduct = await CreateDatabaseProduct(productDto);

            _context.Products.Add(databaseProduct);
            await _context.SaveChangesAsync();
            return productDto;
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            var productItem = await _context.Products.FindAsync(productDto.Id);

            if (productItem == null) return new ProductDto();

            var databaseProduct = await CreateDatabaseProduct(productDto);

            _context.Products.Update(databaseProduct);

            await _context.SaveChangesAsync();

            return productItem.Adapt<ProductDto>();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var productItem = await _context.Products.FindAsync(id);

            if (productItem != null)
            {
                var filesForUploadingLogo = productItem.Logo;

                var filesForUploadingBackground = productItem.Background;

                if (filesForUploadingLogo != null && filesForUploadingBackground != null)
                {
                    var list = new List<string> {filesForUploadingLogo, filesForUploadingBackground};

                    foreach (var itemForDeleting in list)
                    {
                        await _iS3Service.DeleteAwsFileAsync(itemForDeleting);
                    }
                }

                _context.Products.Remove(productItem);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<RateProductDto> RateThisProduct(RateProductDto rateProductUiDto)
        {
            //checking if product id exists in sought table:
            var productItem = await _context.Products.FindAsync(rateProductUiDto.ProductUiId);

            if (productItem == null) return new RateProductDto();

            //take current rating value from product rating table by user and product id`s:
            var ratingCurrentByProductCollection = await _context.ProductRatings.FirstOrDefaultAsync(x =>
                x.ProductId == rateProductUiDto.ProductUiId && x.AppUserId == rateProductUiDto.AppUserUiId); //null

            var ratingCurrentByProductId = ratingCurrentByProductCollection?.Rating ?? 0;

            if (ratingCurrentByProductCollection != null)
            {
                if (ratingCurrentByProductId == rateProductUiDto.UiRate) return new RateProductDto();
                ratingCurrentByProductCollection.Rating = rateProductUiDto.UiRate;
            }
            else
            {
                var productRating = new ProductRating
                {
                    ProductId = rateProductUiDto.ProductUiId,
                    AppUserId = rateProductUiDto.AppUserUiId,
                    Rating = rateProductUiDto.UiRate
                };
                await _context.ProductRatings.AddAsync(productRating);
            }

            //summing from product ratings by product id:
            var sumOfRatingsByProductId = await _context.ProductRatings
                .Where(x => x.ProductId == rateProductUiDto.ProductUiId)
                .Select(x => x.Rating)
                .SumAsync();

            //crutch:
            var sumOfNewRatingsByProductId = sumOfRatingsByProductId - ratingCurrentByProductId + rateProductUiDto.UiRate;

            //update product Total Rating with calculated rating above:
            //var uiProductDtoWithUpdatedTotalRating = await _context.Products.Where(p => p.Id == rateProductUiDto.ProductUiId).ToListAsync();

            productItem.TotalRating = sumOfNewRatingsByProductId;

            //saving all updates in data tables:
            await _context.SaveChangesAsync();

            return productItem.TotalRating.Adapt<RateProductDto>();
        }

        public async Task<ListOfProductsDto> ListMyProduct(SortAndFilterModel sortAndFilterModel,
            PaginationModelDto paginationModelDto)
        {
            var paginationModel = paginationModelDto.Adapt<PaginationModel>();

            var productsCollection = FilterProductsByCriteria(sortAndFilterModel.FilteringTerm.ToString(),
                sortAndFilterModel.Genre, sortAndFilterModel.Rating);

            var numberOfProducts = await productsCollection.CountAsync();

            var productsCollectionProcessed =
                SortProductsCollection(productsCollection, sortAndFilterModel.SortingTerm.ToString(),
                        sortAndFilterModel.SortingDirection.ToString() != "False")
                    .Skip(paginationModel.CalculatedSkip())
                    .Take(paginationModel.NumberOfRowsPerPage);

            var listOfProductsDto = new ListOfProductsDto
            {
                ListOfProducts = productsCollectionProcessed, NumberOfPagesByCriteria = numberOfProducts
            };

            return listOfProductsDto;
        }

        #endregion

        #region Additional service methods

        private IQueryable<Product> FilterProductsByCriteria(string filteringField, Genres genreTerm, Ratings ageTerm)
        {
            return filteringField switch
            {
                "Genre" => _context.Products.Where(x => x.Genre == genreTerm),
                "Age" => _context.Products.Where(s => s.RatingByAge == ageTerm),
                _ => null
            };
        }
    
        private static IQueryable<Product> SortProductsCollection(IQueryable<Product> result, string sortingTerm,
            bool reverse) => result.OrderBy(sortingTerm + (reverse ? "descending" : ""));

        private async Task<IEnumerable<string>> ReturnUrisOfPhotos(List<IFormFile> formFiles)
        {
            return await Task.WhenAll(from element in formFiles select _iS3Service.UploadFileAsync(element));
        }

        private async Task<Product> CreateDatabaseProduct(ProductDto productDto)
        {
            var filesForUploadingLogo = productDto.Logo;

            var filesForUploadingBackground = productDto.Background;

            var returnedListOfPhotos = await ReturnUrisOfPhotos(new List<IFormFile>
                {filesForUploadingLogo, filesForUploadingBackground});

            var listReturned = returnedListOfPhotos.ToList();

            var databaseProduct = new Product();

            databaseProduct.Id = productDto.Id;

            databaseProduct.Name = string.IsNullOrEmpty(productDto.Name) ? "n/a" : productDto.Name;

            databaseProduct.Category = productDto.Category;

            databaseProduct.DateCreated = productDto.DateCreated;

            databaseProduct.Genre = productDto.Genre;

            databaseProduct.RatingByAge = productDto.RatingByAge;

            databaseProduct.Price = productDto.Price;

            databaseProduct.Count = productDto.Count;

            databaseProduct.Logo = string.IsNullOrEmpty(listReturned[0]) ? "n/a" : listReturned[0];

            databaseProduct.Background = string.IsNullOrEmpty(listReturned[1]) ? "n/a" : listReturned[1];

            return databaseProduct;
        }

        #endregion
    }
}