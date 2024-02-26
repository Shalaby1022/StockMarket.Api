using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockMarket.Api.Jwt_Services.ServiceInterface;
using StockMarket.Models.DTO_s.AccountDtos;
using StockMarket.Models.ManualMappingUsingExtensionMethods;
using StockMarket.Models.Models;
using System.Runtime.InteropServices;

namespace StockMarket.Api.Controllers
{
    [Route("api/account")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , ILogger<AccountController> logger,
            ITokenService tokenService ,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _signInManager = signInManager;
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
                        return Ok(
                             new NewUserDto
                             {
                                 Email = register.Email,
                                 userName = register.UserName,
                                 Token = _tokenService.CreateToken(mappedCreatedUSer)
                             });

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

        [HttpPost("Login")]
        public async Task<IActionResult> LoginIntoAccount(LoginDto login)
        {
            try
            {

                if (login == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userEXistenec = await _userManager.FindByEmailAsync(login.Email);

                if (userEXistenec == null)
                {
                    return Unauthorized("Invalid Email Or Password");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(userEXistenec, login.Password, false);
                if (!result.Succeeded)
                {
                    return Unauthorized("Invalid Email Or Password");
                }
                else
                {
                    return Ok(
                        new NewUserDto
                        {
                            Email = login.Email,
                            Token = _tokenService.CreateToken(userEXistenec)
                        });
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user Login Proccess.");
                return StatusCode(500, "An error occurred while Trying Logging You In. Please try again later. NB: It'not Your Fault");
            }

        }


    }
}
