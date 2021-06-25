using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Web.Bussiness.DTOs;
using Web.Bussiness.Services.AccountManagement;
using Web.DAL.Models;

namespace Web.Bussiness.Services.OrdersManagement
{
    public class OrdersService : IOrdersService
    {
        private readonly Random _random = new Random();
        private static IConfiguration _configuration;
        private static AppIdentityDbContext _context;
        private static ITokenService _tokenService;

        public OrdersService(AppIdentityDbContext context, IConfiguration configuration, ITokenService tokenService)
        {
            _configuration = configuration;
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<int> CreateOrder(CreateOrderDto createOrderDto)
        {
            var newOrder = new Order {OrderNumber = _random.Next(10000, 20000)};

            await _context.Orders.AddAsync(newOrder);

            await _context.SaveChangesAsync();

            var product = await _context.Products.FindAsync(createOrderDto.ProductId);

            if (product == null) return 0;

            var newOrderProduct = new OrderProduct()
            {
                ProductId = product.Id,

                OrderId = newOrder.OrderId,

                AmountOfProducts = createOrderDto.AmountOfProducts
            };

            await _context.OrderProducts.AddAsync(newOrderProduct);

            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<Product>> ListProductsInOrderByOrderId(int orderId)
        {

            var results = await _context.Products
                .Join(_context.OrderProducts, prod => prod.Id, orderProd => orderProd.ProductId, (prod, orderProd) => new { prod, orderProd })
                .Select(x => new Product
                {
                    Id = x.prod.Id,
                    Name = x.prod.Name,
                    Genre = x.prod.Genre,
                    RatingByAge = x.prod.RatingByAge,
                    DateCreated = x.prod.DateCreated,
                    Price = x.prod.Price,
                    Count = x.prod.Count,
                    TotalRating = x.prod.TotalRating
                }).ToListAsync();

            return results;
        }

        public Task<IActionResult> ListAllProductsToBuy()
        {
            throw new System.NotImplementedException();
        }
    }
}