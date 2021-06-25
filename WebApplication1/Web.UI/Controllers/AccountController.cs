using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Bussiness.Models.UserModels;
using Web.Bussiness.Services.AccountManagement;

namespace Web.UI.Controllers
{
    /// <summary>
    /// Initial API class for account 
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Private fields
        private readonly IAccountService _accountService;
        #endregion

        #region Constructor
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        #endregion

        #region Login
        [HttpPost("login")]
        [Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Login(LoginModel loginModel)
        {
            var result =  await _accountService.Login(loginModel);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(); ;
        }
        #endregion

        #region SignUp
        [HttpPost("signUp")]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> SignUp(CreateUserModel createUserModel)
        {
            return await _accountService.SignUp(createUserModel);
        }
        #endregion

        #region Logout
        [HttpPost("logout")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Logout()
        {
            return Ok(await _accountService.Logout());
        }
        #endregion
    }
}
