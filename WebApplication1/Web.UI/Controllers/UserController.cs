using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Bussiness.DTOs;
using Web.Bussiness.Services.UserManagement;
using Web.DAL.Models;

namespace Web.UI.Controllers
{
    /// <summary>
    /// Initial API class for user 
    /// </summary>
    [Authorize(Roles = "Admins")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Private fields
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        [HttpPut]
        //[Authorize]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> EditUser(EditUserModelDto editUserModelDto)
        {
            return await _userService.EditUser(editUserModelDto);
        }

        [HttpPost("password")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> UpdateUsersPassword(string id, string password)
        {
            return await _userService.UpdateUsersPassword(id, password);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AppUser>> GetById([FromQuery]string id)
        {
            var element = await _userService.GetById(id);

            if (element != null)
            {
                return Ok(element);
            }

            return NoContent();
        }
    }
}