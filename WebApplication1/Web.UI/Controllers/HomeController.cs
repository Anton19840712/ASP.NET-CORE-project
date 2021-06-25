using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    /// <summary>
    /// Initial API class 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
        #region GetInfo
        /// <summary>
        /// User's hello world get request
        /// </summary>
        /// <remarks>Test methods</remarks>
        /// <returns></returns>
        //[Authorize(Roles = AttributeConstants.AdminsConstant)]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public ActionResult<string> GetInfo()
        {
            return "Hello, world";
        }
        #endregion
    }
}