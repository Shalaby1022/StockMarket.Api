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
    public class StockRepository : GenericRepository<Stock>, IStockRepository<Stock>
    {
        private readonly StockDbContext _context;

        public StockRepository(StockDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllStocksWithInclusion()
        {
            var stocksWithINclusion = await _context.Stocks.Include(a=>a.Comments).ToListAsync();
            return stocksWithINclusion;
        }
    }
}
