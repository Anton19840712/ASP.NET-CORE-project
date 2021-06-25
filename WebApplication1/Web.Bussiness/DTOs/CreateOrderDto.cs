using Microsoft.AspNetCore.Mvc;

namespace Web.Bussiness.DTOs
{
    public class CreateOrderDto
    {
        [FromQuery(Name = "Insert product id")]
        public int ProductId { get; set; }
        [FromQuery(Name = "Insert number of items")]
        public int AmountOfProducts { get; set; }
    }
}