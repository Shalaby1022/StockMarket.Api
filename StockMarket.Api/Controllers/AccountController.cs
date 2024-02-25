using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Models.DTO_s.AccountDtos;
using StockMarket.Models.ManualMappingUsingExtensionMethods;
using StockMarket.Models.Models;

namespace StockMarket.Api.Controllers
{
    [Route("api/account")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager , ILogger<AccountController> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUserAsync([FromBody] RegisterDto register)
        {
            try
            {
                if(register == null)
                {
                    return BadRequest(ModelState);
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (register.Password != register.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
                    return BadRequest(ModelState);
                }


                var mappedCreatedUSer = register.ToAppUSerFromCreation();
                var createUser = await _userManager.CreateAsync(mappedCreatedUSer, register.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(mappedCreatedUSer, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User Created");

                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return StatusCode(500, "Something Bad Happend Don't know What Really");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user registration.");
                return StatusCode(500, "An error occurred while processing your request. Please try again later. NB: It'not Your Fault");
            }
        }


    }
}
