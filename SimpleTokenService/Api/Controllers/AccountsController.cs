using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTokenService.Api;
using SimpleTokenService.Api.Models.Responses;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                var token = await _userService.Authenticate(email, password);

                if (token == null) return StatusCode(StatusCodes.Status401Unauthorized);

                var response = new TokenResponse()
                {
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
    }
}