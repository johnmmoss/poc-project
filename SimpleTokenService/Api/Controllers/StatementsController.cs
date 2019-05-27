using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTokenService.Api.Models.Statements;
using SimpleTokenService.Data.Entities;
using SimpleTokenService.Domain;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleTokenService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IStatementService _statementService;

        public StatementsController(ILogger<StatementsController> logger, IStatementService statementService)
        {
            _logger = logger;
            _statementService = statementService;
        }
        
        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] StatementAddRequest request)
        {
            // Validate the bearer is the request user
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if ( request.EmailAddress.ToLower() != claim.Value.ToLower())
            {
                _logger.LogWarning($"The bearer token email ${claim.Value} does not match the request email ${request.EmailAddress}");

                return StatusCode(StatusCodes.Status401Unauthorized, "Bearer token does not match request!");
            }

            // Current dates coming through as US :( need to sort this out at some point
            var usStartDate = request.StartDate.Value;
            var usEndDate = request.EndDate.Value;
            
            var newStatement = new Statement()
            {
                Title = request.Title,
                StartDate = new DateTime(usStartDate.Year, usStartDate.Month, usStartDate.Day),
                EndDate = new DateTime(usEndDate.Year, usEndDate.Month, usEndDate.Day),
                OpeningBalance = request.OpeningBalance.Value,
            };

            try
            {
                _logger.LogDebug("Adding new Statement...");

                await _statementService.Add(request.EmailAddress, newStatement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error adding new Statement");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }
    }
}
