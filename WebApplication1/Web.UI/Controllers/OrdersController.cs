using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Bussiness.DTOs;
using Web.Bussiness.Services.AccountManagement;
using Web.Bussiness.Services.OrdersManagement;
using Web.DAL.Models;

namespace Web.UI.Controllers
{
    /// <summary>
    /// Initial API class 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Private fields

        private static IOrdersService _ordersService;
        private static ITokenService _tokenService;

        #endregion

        #region Constructor

        public OrdersController(IOrdersService ordersService,ITokenService tokenService)
        {
            _ordersService = ordersService;
            _tokenService = tokenService;
        }

        #endregion

        [HttpPost("orders")]
        //[Authorize]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        public async Task<int> CreateOrder([FromQuery] CreateOrderDto createOrderDto) => await _ordersService.CreateOrder(createOrderDto) != 0 ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest;

        [HttpGet("orders")]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status400BadRequest)]
        public async Task<List<Product>> ListProductsInOrderByOrderId(int orderId) => await _ordersService.ListProductsInOrderByOrderId(orderId);


        [HttpPost("/token")]
        public async Task<string> CreateToken ([FromQuery] TokenModelDto tokenModelDto)
        {
            return await _tokenService.CreateToken(tokenModelDto);
        }
    }
}