using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpaca.Markets;
using AWSLambda.Models;
using Twilio.TwiML.Voice;

namespace AWSLambda.Data
{
    public class alpacaOrders
    {
        public string placeNewOrder(OrderModel order)
        {
            var APCA_API_KEY_ID = Globals.alpacaKeyId;
            var APCA_API_SECRET = Globals.alpacaSecretKey;

            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaTradingClient(new SecretKey(APCA_API_KEY_ID, APCA_API_SECRET));

            // var clock = client.GetClockAsync().Result;
            var accountInformation = client.GetAccountAsync().Result;

            // Submitting a Market Buy Order for 2 Shares of whatever I set up on TradingView
            // TODO - Based off of my TradingView alerts, code logic to hedge losing money 
            var TradingViewOrder = client.PostOrderAsync(
                // new NewOrderRequest("TSLA", 2, OrderSide.Buy, OrderType.Market, TimeInForce.Day));
                new NewOrderRequest($"{order.ticker}", 2, OrderSide.Buy, OrderType.Market, TimeInForce.Day));


            //if (clock != null && accountInformation != null)
            //{
            //    Console.WriteLine(
            //        "Timestamp: {0}, NextOpen: {1}, NextClose: {2}, you'll have {3} to spend!",
            //        clock.Timestamp, clock.NextOpen, clock.NextClose, accountInformation.BuyingPower
            //        );
            //}

            return $"You have {accountInformation.BuyingPower} ready to grow";
        }


    }
}
