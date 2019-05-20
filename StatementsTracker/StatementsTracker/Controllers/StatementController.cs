using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StatementsTracker.Models.Statements;

namespace StatementsTracker.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public IActionResult Add(StatementAddRequest request)
        {
            return Ok(request);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult All()
        {
            return Ok("woop!");
        }
    }
}