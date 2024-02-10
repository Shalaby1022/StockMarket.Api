using Microsoft.EntityFrameworkCore;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Data
{
    public class StockDbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }
    }
}
