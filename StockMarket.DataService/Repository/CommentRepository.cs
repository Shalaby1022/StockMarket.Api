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
    public class CommentRepository : GenericRepository<Comment>, IcommentRepositroy<Comment>
    {
        private readonly StockDbContext _context;

        public CommentRepository(StockDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsWithInclusion()
        {
            var comments = await _context.Comments.Include(a=>a.UserId).ToListAsync();

            return comments;
        }

        public async Task<Comment> GetCommentByIdForInclusion(ApplicationUser user , int id)
        {
            var oneComment = await _context.Comments.Include(a=>a.ApplicationUser.Id).FirstOrDefaultAsync(a=>a.Id == id);

            return oneComment;
        }
    }
}
