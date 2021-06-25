using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Bussiness.Models.UserModels;
using Web.DAL.Models;

namespace Web.Bussiness.Services.RoleAdminManagement
{
    public class RoleAdminService : IRoleAdminService
    {
        #region Private fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        #endregion

        #region Constructor
        public RoleAdminService(RoleManager<IdentityRole> roleMgr, UserManager<AppUser> userMrg)
        {
            _roleManager = roleMgr;
            _userManager = userMrg;
        }
        #endregion

        public async Task<string> CreateRole(string name)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            return result.Succeeded ? "Role was created" : "Role was not created";
        }

        public async Task<string> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return "Role was not found";
            }

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded ? "Role was deleted" : "Role was not deleted";
        }

        /// <summary>
        /// Method changes existing role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<string> EditRole(string userId)
        {
            var role = await _roleManager.FindByIdAsync(userId);

            if (role != null)
            {
                return "NotFound";
            }

            var model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return "user was edited";

        }

        /// <summary>
        /// Method edits Role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> ModifyRole(RoleModificationModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);

            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                return "Role was modified";
            }
            return "NotFound";

        }
    }
}