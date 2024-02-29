using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using StockMarket.DataService.Interfaces;
using StockMarket.Models.DTO_s.CommentDtos;
using StockMarket.Models.DTO_s.StockDtos;
using StockMarket.Models.ManualMappingUsingExtensionMethods;
using StockMarket.Models.Models;
using StockMarket.Utility.Extensions;
using StockMarket.Utility.ResourceParameters;

namespace StockMarket.Api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]

    public class PortfolioController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CommentController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IportfolioRepository<Portfolio> _portfolioRepository;

        public PortfolioController(IUnitOfWork unitOfWork
                                   , ILogger<CommentController> logger
                                   , UserManager<ApplicationUser> userManager
                                   , IportfolioRepository<Portfolio> portfolioRepository
                                   )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _portfolioRepository = portfolioRepository ?? throw new ArgumentNullException(nameof(portfolioRepository));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Portfolio>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetUserPortfolio()
        {
            var userName =  User.GetUSerName();
            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null) { return BadRequest(ModelState); }



            var userPortofolio = await _portfolioRepository.GetUserPortfolio(appUser);
            if (userPortofolio == null) { return NotFound(); }

            

            return Ok(userPortofolio);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateNewPortfolio(int stockId , [FromQuery] StockResourceParameters<Stock> stockResourceParameters)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateNewPortfolio)}");
                return BadRequest(ModelState);
            }

            try
            {

                var userName = User.GetUSerName();
                if(userName == null) { return BadRequest("Can't Get Your Name Make Sure You're already signedIn on Our Site"); }

                var appUser = await _userManager.FindByNameAsync(userName);
                if(appUser == null) { return NotFound();}

                var stock = await _unitOfWork.StockRepository.GetByIdAsync(a => a.Id == stockId);
                if (stock == null) { return BadRequest("Stock Not Found"); }


                var getPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
                if (getPortfolio == null) { return BadRequest(ModelState); }

                if(getPortfolio.Any(e=>e.Id == stockId))
                {
                    return BadRequest("Stock already exists in the portfolio");
                }
           

                var portfolio = new Portfolio
                {
                    UserId = appUser.Id,
                    StockId = stockId,
                };


                 await _unitOfWork.PortfolioRepository.CreateAsync(portfolio);
                 await _unitOfWork.SaveAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating and adding new Comment {nameof(CreateNewPortfolio)}.");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{stockId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeletePortofolio(int stockId)
        {
            if (stockId == null) { return NotFound("There isn't a Stock Associated in a portoflio you want try to delete"); }

            if (!ModelState.IsValid || stockId < 0)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeletePortofolio)}");
                return BadRequest(ModelState);
            }

            try
            {

                var userName = User.GetUSerName();
                if (userName == null) { return BadRequest("Can't Get Your Name Make Sure You're already signedIn on Our Site"); }

                var appUser = await _userManager.FindByNameAsync(userName);
                if (appUser == null) { return NotFound(); }

                var getPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
                if (getPortfolio == null) { return BadRequest(ModelState); }

                var filterStock = getPortfolio.Where(s => s.Id == stockId);

                if (filterStock.Any())
                {
                    _portfolioRepository.DeletePortoflio(appUser, stockId);
                    await _unitOfWork.SaveAsync();

                    return Ok("Deleted Successfuly!!");
                }

                else return BadRequest("There Isn't Stock associated in our portofolio Please enter valid StockId");



            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while Deleting existing Stock {nameof(DeletePortofolio)}.");
                return StatusCode(500, "Internal server error! Please Try again");

            }
        }

        }

}
