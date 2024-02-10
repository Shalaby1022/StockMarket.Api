using Microsoft.EntityFrameworkCore;
using StockMarket.DataService.Data;
using StockMarket.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StockDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(StockDbContext Context)
        {
            _context = Context ?? throw new ArgumentNullException(nameof(Context));
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> enttities)
        {
            await _dbSet.AddRangeAsync(enttities);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> enttities)
        {
            _dbSet.RemoveRange(enttities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;
            return await query.AsNoTracking().ToListAsync();
        }

        public  async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _dbSet;

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            query = query.Where(expression);
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> enttities)
        {
            _dbSet.UpdateRange(enttities);
        }
    }
}
