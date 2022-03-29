using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TechShop.Data.Entities
{

    public class Product {
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название продукта ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите детальное описание")]
        public string DetailedDescription { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Пожалуйста, введите положительную цену")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите тип")]
        public int TypeProductId { get; set; }
        public TypeProduct TypeProducts { get; set; }


        public byte[] Image { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
