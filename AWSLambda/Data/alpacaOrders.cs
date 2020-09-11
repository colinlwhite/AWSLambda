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

            var accountInformation = client.GetAccountAsync().Result;

            // TODO - Based off of my TradingView alerts, code logic to hedge losing money 
            var TradingViewOrder = client.PostOrderAsync(
                new NewOrderRequest($"{order.ticker}", 1, OrderSide.Buy, OrderType.Market, TimeInForce.Day));

            return $"You have {accountInformation.BuyingPower} ready to grow";
        }


    }
}
