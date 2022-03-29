using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechShop.Data.Entities;

namespace TechShop.Models
{
    public class ProductViewModel
    {
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
        //public int TypeProductId { get; set; }
        public string TypeProductName { get; set; }

        public byte[] Image { get; set; }

        public string ReturnUrl { get; set; }
        /// <summary>
        /// для комментария
        /// </summary>
        public List<Comment> Comments { get; set; }
    }
}
