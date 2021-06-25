using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Bussiness.DTOs;
using Web.DAL.Models;

namespace Web.Bussiness.Services.OrdersManagement
{
    public interface IOrdersService
    {
        #region IOrdersService methods
        Task<int> CreateOrder(CreateOrderDto createOrderDto);
        Task<List<Product>> ListProductsInOrderByOrderId(int orderId);
        Task<IActionResult> ListAllProductsToBuy();
        #endregion
    }
}