using System.Threading.Tasks;
using Web.Bussiness.Models.UserModels;

namespace Web.Bussiness.Services.AccountManagement
{
    public interface IAccountService
    {
        Task<string> Logout();
        Task<string> SignUp(CreateUserModel userModel);
        Task<string> Login(LoginModel loginModel);
    }
}