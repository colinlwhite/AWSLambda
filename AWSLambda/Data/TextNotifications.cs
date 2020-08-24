using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AWSLambda.Data
{
    public class TextNotifications
    {
        public void SendTextNotification()
        {
            var accountSid = "ACf52182c66da8da1a8e1d6dee3ea528c7";
            var authToken = "4b8a41cd48a09e6b598a0da652ba5335";
            var number = "+12052278229"; 

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "hello Colin",
                from: new Twilio.Types.PhoneNumber("+16154929390"),
                to: new Twilio.Types.PhoneNumber(number)
                );
        }
    }
}
