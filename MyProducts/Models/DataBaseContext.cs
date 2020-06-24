using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProducts.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Providers> Providers { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<Costs> Costs { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
