using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatementsTracker.Data;
using StatementsTracker.Data.Entities;
using StatementsTracker.Data.Extensions;

namespace StatementsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private StatementsContext _context;
        public ValuesController(StatementsContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            EntityCheck();
          

            return new string[] { "value1", "value2" };
        }

        public void EntityCheck()
        {
            //// Update a payment method
            //var payment = _context.Payments.Include(x => x.Method).FirstOrDefault();
            ////PaymentMethodEnum paymentMethod = payment.Method;
            //payment.MethodEnum = PaymentMethodEnum.Cheque;
            //payment.TypeEnum = PaymentTypeEnum.Credit;
            //_context.SaveChanges();

            var newPayment = new Payment();
            newPayment.Amount = 30;
            newPayment.Description = "Food";
            newPayment.IsPending = false;
            newPayment.TypeEnum = PaymentTypeEnum.Credit;
            //newPayment.MethodEnum = PaymentMethodEnum.BankTransfer;
            newPayment.StatementId = 1;

            _context.Payments.Add(newPayment);
            _context.SaveChanges();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
