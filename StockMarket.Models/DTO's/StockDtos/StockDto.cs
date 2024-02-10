using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Models.DTO_s.StockDtos
{
    public class StockDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Symbol is required")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Symbol length must be between 1 and 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Company name length must be between 1 and 100 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Purchase price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Purchase price must be greater than or equal to 0")]
        public decimal Purchase { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Last dividend must be greater than or equal to 0")]
        public decimal? LastDiv { get; set; }

        [Required(ErrorMessage = "Industry is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Industry length must be between 1 and 50 characters")]
        public string Industry { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Market capitalization must be greater than or equal to 0")]
        public decimal? MarketCap { get; set; }
    }
}
