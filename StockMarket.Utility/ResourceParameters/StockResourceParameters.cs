using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Utility.ResourceParameters
{
    public class StockResourceParameters<T> where T : class
    {
        const int MaxPageSize = 20;
        public string? FilterQuery { get; set; }
        public string? SearchQuery { get; set; }

        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value>MaxPageSize) ? MaxPageSize : value;

        }





    }
}
