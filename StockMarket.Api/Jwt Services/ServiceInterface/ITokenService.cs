using StockMarket.Models.Models;

namespace StockMarket.Api.Jwt_Services.ServiceInterface
{
    public interface ITokenService
    {
     string CreateToken(ApplicationUser applicationUser);

    }
}
