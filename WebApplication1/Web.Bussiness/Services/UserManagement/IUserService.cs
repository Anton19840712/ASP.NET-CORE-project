using System.Threading.Tasks;
using Web.Bussiness.DTOs;
using Web.DAL.Models;

namespace Web.Bussiness.Services.UserManagement
{
    public interface IUserService
    {
        Task<string> EditUser(EditUserModelDto editUserModelDto);
        Task<string> UpdateUsersPassword(string id, string password);
        Task<AppUser> GetById(string id);
    }
}