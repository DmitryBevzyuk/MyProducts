using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
