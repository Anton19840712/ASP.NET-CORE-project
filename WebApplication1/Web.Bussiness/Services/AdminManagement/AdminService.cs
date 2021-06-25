using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Bussiness.DTOs;
using Web.Bussiness.Extensions;
using Web.Bussiness.Models.UserModels;
using Web.DAL.Models;

namespace Web.Bussiness.Services.AdminManagement
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserValidator<AppUser> _userValidator;
        private readonly IPasswordValidator<AppUser> _passwordValidator;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        public AdminService(UserManager<AppUser> usrMgr, IUserValidator< AppUser > userValid, IPasswordValidator<AppUser> passValid, IPasswordHasher< AppUser > passwordHash)
        {
            _userManager = usrMgr;
            _userValidator = userValid;
            _passwordValidator = passValid;
            _passwordHasher = passwordHash;
        }
        public async Task<string> CreateAdmin(CreateUserModel userModel)
        {
            var user = new AppUser
            {
                UserName = userModel.Name,
                Email = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return !result.Succeeded ? "Admin was not created" : "Admin was created";
        }

        public async Task<string> DeleteAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            var result = await _userManager.DeleteAsync(user);

            return !result.Succeeded ? "Admin was not deleted" : "Admin was deleted";
        }

        public async Task<string> EditAdmin(EditUserModelDto editUserModelDto)
        {
            var editUser = editUserModelDto.CreateThisLayerEditUser();

            var userModel = new CreateUserModel {Name = editUser.Name, Email = editUser.Email, Password = editUser.Password};

            var user = await _userManager.FindByIdAsync(editUserModelDto.Id);

            user.Email = userModel.Email;

            user.PasswordHash = _passwordHasher.HashPassword(user, editUser.Password);

            var result = await _userManager.UpdateAsync(user);

            return !result.Succeeded ? "Admin was not edited" : "Admin was edited";
        }

        
    }
}