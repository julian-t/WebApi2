using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public class Trade
    {
        public string Symbol { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public long Volume { get; set; }
        public DateTime When { get; set; }
        public string TraderID { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2}/{3} {4} {5})", Symbol, Volume, BuyPrice, SellPrice, When, TraderID);
        }
    }
}