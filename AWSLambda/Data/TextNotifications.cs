using AWSLambda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;

namespace AWSLambda.Data
{
    public class TextNotifications
    {
        public void SendTextNotification(OrderModel order)
        {
            var accountSid = Globals.twilioSID;
            var authToken = Globals.twilioAuthToken;
            var toNumber = Globals.inboundPhoneNumber;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"{order.ticker} has triggered an alert and placed an order",
                from: new Twilio.Types.PhoneNumber(Globals.outboundPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toNumber)
                );
        }
    }
}
