using StockMarket.DataService.Repository;
using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Interfaces
{
    public interface IportfolioRepository<Potfolio> : IGenericRepository<Portfolio>
    {
        Task<List<Stock>> GetUserPortfolio(ApplicationUser user);

        void DeletePortoflio(ApplicationUser user , int StockId);

    }
}
