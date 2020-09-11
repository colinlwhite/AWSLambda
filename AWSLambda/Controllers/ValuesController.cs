using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSLambda.Models;
using Microsoft.AspNetCore.Mvc;
using AWSLambda.Data;

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
            // TODO - Determine if dependency injection is needed for the use of Twilio's API
            // TODO - Ensure that the first text message only notifies me that there's an alert
            TextNotifications textNotifications = new TextNotifications();
            textNotifications.SendTextNotification(order);

            // TODO - Determine if Dependency Injection is needed for the use of Alpaca's API
            alpacaOrders alpacaClient = new alpacaOrders();
            string orderConfirmation = alpacaClient.placeNewOrder(order);

            return $"You've received a TradingView alert for {order.ticker} which opened at ${order.open} today. {orderConfirmation}";
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
