using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Bussiness.Models.UserModels;
using Web.Bussiness.Services.RoleAdminManagement;

namespace Web.UI.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RoleAdminController : ControllerBase
    {
        #region Private fields
        private readonly RoleAdminService _roleAdminService;
        #endregion

        #region Constructor
        public RoleAdminController(RoleAdminService roleAdminService)
        {
            _roleAdminService = roleAdminService;
        }
        #endregion

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Create([Required] string name)
        {
            return await _roleAdminService.CreateRole(name);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(string id)
        {
            return await _roleAdminService.DeleteRole(id);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("{id}")]
        public async Task<ActionResult<string>> Edit([FromQuery] string id)
        {
            return Ok(await _roleAdminService.EditRole(id));
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<string>> Modify(RoleModificationModel model)
        {
            return await _roleAdminService.ModifyRole(model);
        }
    }
}