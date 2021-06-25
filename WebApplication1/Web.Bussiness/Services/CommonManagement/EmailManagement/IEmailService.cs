using System.Threading.Tasks;
using Web.Bussiness.Models.ServiceModels;
using Web.Bussiness.Models.UserModels;

namespace Web.Bussiness.Services.CommonManagement.EmailManagement
{
    public interface IEmailService
    {
        Task<EmailModel> CreateMailModelAsync(CreateUserModel userModel);
        Task SendEmailAsync(EmailModel model);
    }
}