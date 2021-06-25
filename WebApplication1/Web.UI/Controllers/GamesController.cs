using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Web.Bussiness.Services.GamesManagement;
using Web.Bussiness.DTOs;
using Web.Bussiness.Models.UserModels;
using Web.DAL.Models;

namespace Web.UI.Controllers
{

    /// <summary>
    /// Initial API class for games 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        #region Private fields
        private static IObjectsManipulationGamesService _objectsManipulationGamesService;
        private static IDataManipulationGameService _dataManipulationGameService;
        #endregion

        #region Constructor
        public GamesController(IObjectsManipulationGamesService objectsManipulationGamesService, IDataManipulationGameService dataManipulationGameService)
        {
            _objectsManipulationGamesService = objectsManipulationGamesService;
            _dataManipulationGameService = dataManipulationGameService;
        }
        #endregion

        #region Methods
        [HttpGet("topCategories")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<string>>> GetTopThreeCategoriesByQuantity()
        {
            return await _dataManipulationGameService.GetTopThreeCategoriesByQuantity();
        }

        [HttpGet("search")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<List<Product>> FilterProductsByTermWithLimitNumber([FromQuery] TermAndLimitModel termAndLimit)
        {
            return await _dataManipulationGameService.FilterProductsByTermWithLimitNumber(termAndLimit.Term, termAndLimit.Limit);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ProductDto> FindProductById(int id)
        {
            return await _dataManipulationGameService.FindProductById(id);
        }

        [HttpPost("model-plus-files")]
        //[Authorize(Roles = "Admin, PowerUser")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ProductDto> CreateNewProduct([FromForm] ProductDto productDto)
        {
            return await _objectsManipulationGamesService.CreateNewProduct(productDto);
        }

        [HttpPut]
        //[Authorize(Roles = "Admin, PowerUser")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ProductDto> UpdateProduct([FromForm] ProductDto productDto)
        {
            return await _objectsManipulationGamesService.UpdateProduct(productDto);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin, PowerUser")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await _objectsManipulationGamesService.DeleteProduct(id) == false ? (IActionResult) BadRequest("Failed to delete the product") : Ok();
        }

        [HttpPost("rating")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RateProductDto>> RateThisProduct([FromForm] RateProductDto rateProductDto)
        {
            var result = await _dataManipulationGameService.RateThisProduct(rateProductDto);

            if (result==null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet("products/list")]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(Tuple<IEnumerable<Product>, string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ListOfProductsDto> ListMyProduct([FromQuery] SortAndFilterModel sortAndFilterModel, [FromQuery] PaginationModelDto paginationModelDto)
        {
            return await _dataManipulationGameService.ListMyProduct(sortAndFilterModel, paginationModelDto);
        }
        #endregion
    }
}