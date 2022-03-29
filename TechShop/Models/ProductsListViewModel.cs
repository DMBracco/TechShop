using System.Collections.Generic;
using TechShop.Data.Entities;

namespace TechShop.Models
{

    public class ProductsListViewModel {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentTypeProduct { get; set; }
    }
}
