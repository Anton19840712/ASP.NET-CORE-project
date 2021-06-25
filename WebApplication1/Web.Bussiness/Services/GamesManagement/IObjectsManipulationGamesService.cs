using System.Threading.Tasks;
using Web.Bussiness.DTOs;

namespace Web.Bussiness.Services.GamesManagement
{
    public interface IObjectsManipulationGamesService
    {
        #region IGamesService methods
        Task<ProductDto> CreateNewProduct(ProductDto productDto);
        Task<ProductDto> UpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int id);
        #endregion
    }
}