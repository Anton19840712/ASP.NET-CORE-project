using System.Threading.Tasks;
using Web.Bussiness.Models.UserModels;

namespace Web.Bussiness.Services.RoleAdminManagement
{
    public interface IRoleAdminService
    {
        Task<string> CreateRole(string name);
        Task<string> DeleteRole(string id);
        Task<string> EditRole(string element);
        Task<string> ModifyRole(RoleModificationModel model);
    }
}