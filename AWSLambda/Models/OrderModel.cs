using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSLambda.Models
{
    public class OrderModel
    {
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal close { get; set; }
        public string exchange { get; set; }
        public string ticker { get; set; }
        public decimal volume { get; set; }
        public string time { get; set; }
        public string timeNow { get; set; }
    }
}
