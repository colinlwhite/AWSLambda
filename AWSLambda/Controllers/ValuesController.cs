using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSLambda.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWSLambda.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Colin", "White" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "AWS Certified Cloud Practitioner";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] OrderModel order)
        {
            return $"You've received a TradingView alert for {order.ticker} which opened at ${order.open} today.";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
