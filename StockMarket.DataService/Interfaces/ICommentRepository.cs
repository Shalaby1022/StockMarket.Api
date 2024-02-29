using StockMarket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.DataService.Interfaces
{
    public interface IcommentRepositroy<Comment> : IGenericRepository<StockMarket.Models.Models.Comment>
    {
        Task<IEnumerable<StockMarket.Models.Models.Comment>> GetAllCommentsWithInclusion();

        Task<StockMarket.Models.Models.Comment> GetCommentByIdForInclusion(ApplicationUser user ,  int id);
    }
}
