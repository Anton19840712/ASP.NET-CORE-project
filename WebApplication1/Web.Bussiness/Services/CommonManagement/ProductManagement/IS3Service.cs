using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web.Bussiness.Services.CommonManagement.ProductManagement
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile imageLink);
        Task DeleteAwsFileAsync(string file);
    }
}