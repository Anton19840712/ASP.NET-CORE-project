using System.Collections.Generic;
using Web.DAL.Models;

namespace Web.Bussiness.DTOs
{
    public class ListOfProductsDto
    {
        public IEnumerable<Product> ListOfProducts { get; set; }
        public int NumberOfPagesByCriteria { get; set; }
        
    }
}