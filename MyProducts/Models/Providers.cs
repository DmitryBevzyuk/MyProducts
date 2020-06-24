using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Models
{
    public class Providers
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите название поставщика")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
