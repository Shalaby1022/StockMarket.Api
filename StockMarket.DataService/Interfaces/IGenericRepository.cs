using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> enttities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> enttities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> enttities);
    }
}
