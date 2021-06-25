using System.Threading.Tasks;
using Web.Bussiness.DTOs;

namespace Web.Bussiness.Services.AccountManagement
{
    public interface ITokenService
    {
        Task<string>CreateToken(TokenModelDto tokenModelDto);
    }
}