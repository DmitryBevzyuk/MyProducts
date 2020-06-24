using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Models
{
    public class Costs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите код товара из прайс листа")]
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите значение объёма продаж")]
        public int? Volume { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите сумму затрат на 1 ед. данного товара")]
        public decimal? Cost { get; set; }
    }
}
