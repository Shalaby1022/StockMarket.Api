using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.Models
{
    public class Portfolio
    {
        public int StockId { get; set; }
        public Stock? Stock { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
