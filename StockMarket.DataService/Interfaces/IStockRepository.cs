using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Interfaces
{
    public interface IStockRepository<Stock> : IGenericRepository<StockMarket.Models.Models.Stock>
    {
        Task<IEnumerable<Stock>> GetAllStocksWithInclusion();



    }
}
