using System.Collections.Generic;

namespace TechShop.Data.Entities
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
