using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Bussiness.DTOs;
using Web.Bussiness.Extensions;
using Web.Bussiness.Models.UserModels;
using Web.DAL.Models;

namespace Web.Bussiness.Services.UserManagement
{
    public class UserService : IUserService
    {
        #region Private fields
        private readonly UserManager<AppUser> _userManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        #endregion

        #region Constructor
        public UserService(UserManager<AppUser> usrMgr, IPasswordHasher<AppUser> passwordHash)
        {
            _userManager = usrMgr;
            _passwordHasher = passwordHash;
        }
        #endregion

        #region EditUser
        public async Task<string> EditUser(EditUserModelDto editUserModelDto)
        {
            var user = await _userManager.FindByIdAsync(editUserModelDto.Id);

            var editUser = editUserModelDto.CreateThisLayerEditUser();

            var userModel = new CreateUserModel { Name = editUser.Name, Email = editUser.Email, Password = editUser.Password };

            user.Email = userModel.Email;

            user.PasswordHash = _passwordHasher.HashPassword(user, editUser.Password);

            var result = await _userManager.UpdateAsync(user);

            return !result.Succeeded ? "Admin was not edited" : "Admin was edited";
        }

        #endregion

        #region UpdateUsersPassword
        /// <summary>
        /// Method updates user`s password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> UpdateUsersPassword(string id, string password)
        {
            var userToSearch = await _userManager.FindByIdAsync(id);

            userToSearch.PasswordHash = _passwordHasher.HashPassword(userToSearch, password);

            var result = await _userManager.UpdateAsync(userToSearch);

            if (result.Succeeded)
            {
                return "Users password was updated";
            }
            return "Users password was not updated";
        }
        #endregion

        #region GetById
        /// <summary>
        /// Method returns user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AppUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        #endregion
    }
}