using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Data
{
    public class StockDbContext : IdentityDbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",

                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",

                },
            };
            builder.Entity<IdentityRole>().HasData(roles);


            builder.Entity<Stock>()
                  .HasMany(a => a.ApplicationUsers)
                  .WithMany(s => s.Stocks)
                  .UsingEntity<Portfolio>(

                  p => p
                       .HasOne(a => a.ApplicationUser)
                       .WithMany(p => p.Portfolios)
                       .HasForeignKey(u => u.UserId),

                 p => p
                      .HasOne(s => s.Stock)
                      .WithMany(s => s.Portfolios)
                      .HasForeignKey(u => u.StockId),

                 p =>
                 {
                     p.HasKey(c => new { c.StockId, c.UserId });
                 });
        }
    }
}
