using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<Stock> StockRepository { get; }
        IGenericRepository<Portfolio> PortfolioRepository { get; }

        Task SaveAsync();
    }
}
