using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DataService.Interfaces;
using StockMarket.Models.DTO_s.StockDtos;
using StockMarket.Models.Models;

namespace StockMarket.Api.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StockController> _logger;
        private readonly IMapper _mapper;

        public StockController(IUnitOfWork unitOfWork
                                          , ILogger<StockController> logger
                                          , IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Stock>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStocks()
        {
            try
            {
                var stocks = await _unitOfWork.StockRepository.GetAllAsync();
                var mappedStocks = _mapper.Map<StockDto>(stocks);

                return Ok(mappedStocks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error Occurred While Retreiveing The Stocks Info {nameof(GetAllStocks)}");
                return StatusCode(500, "Internal Server Error!!");

            }
        }

        [HttpGet("{stockId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetStockById(int? stockId)
        {
            try
            {
                if (stockId == null) return BadRequest("StockId can't be NUll Value");

                var stock = await _unitOfWork.StockRepository.GetByIdAsync(c => c.Id == stockId);

                if (stock == null) return NotFound();

                var mappedStock = _mapper.Map<StockDto>(stock);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(mappedStock);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing GetUserById.");
                return StatusCode(500, "Internal server error!!");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateNewStock([FromBody] CreateStockDto createStockDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(createStockDto)}");
                return BadRequest(ModelState);
            }

            try
            {
                if (createStockDto == null) return BadRequest(ModelState);

                var stockMap = _mapper.Map<Stock>(createStockDto);
                if (stockMap == null)
                {
                    ModelState.AddModelError("", "Mapping failed. Unable to create stock.");
                    return BadRequest(ModelState);
                }

                await _unitOfWork.StockRepository.CreateAsync(stockMap);
                await _unitOfWork.SaveAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating and adding new country {nameof(createStockDto)}.");
                return StatusCode(500, "Internal server error");
            }
        }







    }
}
