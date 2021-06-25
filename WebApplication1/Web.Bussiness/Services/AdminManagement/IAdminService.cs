using System.Threading.Tasks;
using Web.Bussiness.DTOs;
using Web.Bussiness.Models.UserModels;

namespace Web.Bussiness.Services.AdminManagement
{
    public interface IAdminService
    {
        Task<string>CreateAdmin(CreateUserModel userModel);
        Task<string> DeleteAdmin(string id);
        Task<string> EditAdmin(EditUserModelDto editUserModelDto);
    }
}