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
    public class UnitOfWorkRepository : IUnitOfWork

    {
        private readonly StockDbContext _context;
        private IGenericRepository<Stock> _stockRepository;
        private IGenericRepository<Comment> _commentRepository;
        public UnitOfWorkRepository(StockDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Stock> StockRepository => _stockRepository ?? new GenericRepository<Stock>(_context);
        public IGenericRepository<Comment> CommentRepository => _commentRepository ?? new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
