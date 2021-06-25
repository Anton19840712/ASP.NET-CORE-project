using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Web.Bussiness.Models.UserModels;
using Web.Bussiness.Services.CommonManagement.EmailManagement;
using Web.DAL.Models;

namespace Web.Bussiness.Services.AccountManagement
{
    public class AccountService : IAccountService
    {
        #region Private fields
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        #endregion

        #region Constructor
        public AccountService(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr, IConfiguration configuration, IEmailService emailService)
        {
            _userManager = userMgr;
            _signInManager = signInMgr;
            _configuration = configuration;
            _emailService = emailService;
        }
        #endregion

        /// <summary>
        /// Method enables login to user.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Name);
            if (user != null)
            {
                await _signInManager.SignOutAsync();

                if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                {
                    return "You are logged in";
                }
            }
            return "No user found";
        }
        /// <summary>
        /// Method sign ups new user.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<string> SignUp(CreateUserModel userModel)
        {
            AppUser appUserModel = new AppUser();

            var isUserNameValid = appUserModel.IsNameValid(userModel.Name);

            if (!isUserNameValid) return "User is not valid";

            //User creation
            var user = CreateAppUser(userModel);

            //Email sender
            await SendEmail(userModel);

            return "You are signed up, check specified email to confirm registration.";
        }

        /// <summary>
        /// Method creates user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        private static AppUser CreateAppUser(CreateUserModel userModel)
        {
            var user = new AppUser
            {
                UserName = userModel.Name,
                Email = userModel.Email
            };
            return user;
        }
        /// <summary>
        /// Method enables to send email.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        private async Task SendEmail(CreateUserModel userModel)
        {
            var mailModel = await _emailService.CreateMailModelAsync(userModel);

            await _emailService.SendEmailAsync(mailModel);
        }
        /// <summary>
        /// Method enables logout.
        /// </summary>
        /// <returns></returns>
        public async Task<string> Logout()
        {
           await _signInManager.SignOutAsync();

           return "You are signed out";
        }
    }
}