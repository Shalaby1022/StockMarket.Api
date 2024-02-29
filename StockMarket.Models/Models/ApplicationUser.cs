using Microsoft.AspNetCore.Identity;

namespace StockMarket.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;

        //navigation Props
        public List<Stock> Stocks { get; set; } = new List<Stock>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    }
}
