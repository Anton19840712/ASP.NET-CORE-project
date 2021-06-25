using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Bussiness.DTOs;
using Web.Bussiness.Models.UserModels;
using Web.Bussiness.Services.AdminManagement;

namespace Web.UI.Controllers
{
    /// <summary>
    /// Initial API class for admin 
    /// </summary>
    //[Authorize(Roles = "Admins")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        /// <summary>
        /// Admins post sample method
        /// </summary>
        /// <remarks>Test methods</remarks>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Create(CreateUserModel userModel)
        {
            return await _adminService.CreateAdmin(userModel);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            return await _adminService.DeleteAdmin(id);
        }

        [HttpPut("editModel")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Edit([FromBody] EditUserModelDto editUserDtoModel)
        {
            return await _adminService.EditAdmin(editUserDtoModel);
        }
    }
}