using Microsoft.EntityFrameworkCore;
using StockMarket.DataService.Data;
using StockMarket.DataService.Interfaces;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Repository
{
    public class PortfolioRepository : GenericRepository<Portfolio> , IportfolioRepository<Portfolio>
    {
        private readonly StockDbContext _context;

        public PortfolioRepository(StockDbContext context) : base(context)
        {
            _context = context;
        }

        public void DeletePortoflio(ApplicationUser user, int StockId)
        {
            var portofolioDeleted =  _context.Portfolios.FirstOrDefault(s=>s.ApplicationUser == user && s.StockId == StockId);
            _context.Remove(portofolioDeleted);
        }

        public async Task<List<Stock>> GetUserPortfolio(ApplicationUser user)
        {
            var userPortofolio =  await _context.Portfolios.Where(u => u.UserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap,

                }).ToListAsync();

            return userPortofolio;

        }
    }
}
