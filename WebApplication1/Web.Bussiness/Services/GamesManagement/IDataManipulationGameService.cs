using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Bussiness.DTOs;
using Web.Bussiness.Models.UserModels;
using Web.DAL.Models;

namespace Web.Bussiness.Services.GamesManagement
{
    public interface IDataManipulationGameService
    {
        #region IGamesService methods
        Task<List<string>> GetTopThreeCategoriesByQuantity();
        Task<List<Product>> FilterProductsByTermWithLimitNumber(string term, int limit);
        Task<ProductDto> FindProductById(int productId);
        Task<RateProductDto> RateThisProduct(RateProductDto rateProductDto);
        Task<ListOfProductsDto> ListMyProduct(SortAndFilterModel sortAndFilterModel, PaginationModelDto paginationModelDto);
        #endregion
    }
}