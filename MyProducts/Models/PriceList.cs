using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Models
{
    public class PriceList
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите код товара")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите код поставщика")]
        public int? ProviderId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите закупочную цену")]
        public decimal? StartPrice { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите рыночную цену")]
        public decimal? EndPrice { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
        public string Description { get; set; }
    }
}
