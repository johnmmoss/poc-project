using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTokenService.Api.Models.Statements;
using SimpleTokenService.Data.Entities;
using SimpleTokenService.Domain;
using System;
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
        public async Task<IActionResult> Post([FromBody] StatementAddRequest request)
        {
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

                await _statementService.Add(newStatement);
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
