using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTokenService.Api.Models.Statements;
using SimpleTokenService.Data.Entities;
using SimpleTokenService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /** 
         * TODO: Add customer Authorisation middleware 
         *       Should check the logged in user, and their role and decide if they can perform
         *       the action that they are trying to do. This is essentially a policy
         *       ref: https://vimeo.com/223982185
         *       
         * - Filter out multiple full stops for number value
         * - Add some error handling after posting back from the server. At the moment just fails quietly
         * - Why do you have to keep logging in all the time?
         * 
         * */

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] StatementAddRequest request)
        {
            // Validate the bearer is the request user
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (request.EmailAddress.ToLower() != claim.Value.ToLower())
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

        [HttpPut]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] StatementUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newEntity = new Statement()
            {
                Id = request.Id,
                Title = request.Title,
                OpeningBalance = request.OpeningBalance.Value,
                StartDate = request.StartDate.Value,
                EndDate = request.EndDate.Value,
            };

            try
            {
                await _statementService.Update(newEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("{emailAddress}")]
        [Authorize]
        public async Task<IActionResult> GetAll(string emailAddress)
        {
            // TODO:- Add some authorisation here e.g. Check the roles to ensure who is allowed to get!

            if (string.IsNullOrEmpty(emailAddress))
            {
                return BadRequest();
            }

            var statements = await _statementService.GetAllByEmailAddress(emailAddress);


            var response = (statements as List<Statement>).Select(x => new StatementsGetAllResponse()
            {
                Id = x.Id,
                Title = x.Title,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                OpeningBalance = x.OpeningBalance,
                ClosingBalance = x.ClosingBalance
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("user/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            // For now, just return which ever statement is requested
            // This needs securing by role based authorisation using some middleware (or something)
            var statement = await _statementService.GetById(id);

            if (statement == null)
            {
                return NotFound();
            }

            var response = new StatementsGetAllResponse()
            {
                Id = statement.Id,
                Title = statement.Title,
                StartDate = statement.StartDate,
                EndDate = statement.EndDate,
                OpeningBalance = statement.OpeningBalance,
                ClosingBalance = statement.ClosingBalance
            };

            return Ok(response);
        }
    }
}
