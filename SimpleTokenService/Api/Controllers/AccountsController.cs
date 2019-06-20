using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTokenService.Api.Models.Accounts;
using SimpleTokenService.Domain.Interfaces;
using SimpleTokenService.Domain.Settings;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public AccountsController(JwtSettings jwtSettings, IUserService userService)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
        }
        


        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request )
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                var token = await _userService.Authenticate(request.EmailAddress, request.Password);

                var response = new SignInResponse()
                {
                    Success = token != null,
                    Token = token,
                    Expires = "300"
                };
                
               return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users); 
        }

    }
}