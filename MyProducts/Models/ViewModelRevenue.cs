using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Models
{
    public class ViewModelRevenue
    {
        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
        public decimal? Cost { get; set; }
        public int? Volume { get; set; }
        public int Id { get; set; }
    }

    public class ViewModelRevenueList
    {
        public List<ViewModelRevenue> list { get; set; } = new List<ViewModelRevenue>();
        private List<decimal?> revenueList;

        public List<decimal?> RevenueList
        {
            get
            {
                if (revenueList == null)
                    revenueList = DictionaryRevenue();

                return revenueList;
            }
        }

        public void Add(decimal? sp, decimal? ep, decimal? c, int? v, int i)
        {
            list.Add(new ViewModelRevenue
            {
                StartPrice = sp,
                EndPrice = ep,
                Cost = c,
                Volume = v,
                Id = i
            });
        }

        public decimal? getAllRevenue()
        {
            decimal? result = 0;
            foreach (var item in list)
            {
                result += item.Volume * (item.EndPrice - item.StartPrice - item.Cost);
            }
            return result;
        }

        private List<decimal?> DictionaryRevenue()
        {
            decimal? sum = 0;
            List<decimal?> results = new List<decimal?>();
            foreach (var item in list)
            {
                sum = item.Volume * (item.EndPrice - item.StartPrice - item.Cost);
                results.Add(sum);
            }
            revenueList = results;
            return results;
        }
    }
}
