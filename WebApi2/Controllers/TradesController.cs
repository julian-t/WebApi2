using NLog;
using System.Web.Http;
using WebApi2.Models;
using System.Collections.Generic;

namespace WebApi2.Controllers
{
    public class TradesController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private Trade atrade = new Trade() { Symbol="MSFT", BuyPrice=110.1, SellPrice=111.2, Volume=1000, TraderID="Dave", When=new System.DateTime() };

        private IList<Trade> trades = new List<Trade>() {
            new Trade() { Symbol="MSFT", BuyPrice=110.1, SellPrice=111.2, Volume=1000, TraderID="Dave", When=System.DateTime.Now },
            new Trade() { Symbol="AAPL", BuyPrice=210.5, SellPrice=211.6, Volume=100, TraderID="Pete", When=System.DateTime.Now },
            new Trade() { Symbol="GOOG", BuyPrice=100.3, SellPrice=111.2, Volume=210, TraderID="Dave", When=System.DateTime.Now },
            new Trade() { Symbol="MSFT", BuyPrice=109.0, SellPrice=110.1, Volume=1045, TraderID="Pete", When=System.DateTime.Now },
            new Trade() { Symbol="ABCD", BuyPrice=70.6, SellPrice=70.7, Volume=10, TraderID="Bill", When=System.DateTime.Now }
        };

        // /api/trades
        [HttpGet]
        //public string Get()
        //{
        //    logger.Trace("Get all trades");
        //    return "GET all trades";
        //}
        public IHttpActionResult Get()
        {
            logger.Trace("Get all trades");
            return Ok(trades);
        }

        // /api/trades/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            logger.Info("Get for id={0}", id);
            // Automatically serializes the trade based on what the caller wants
            return Ok(atrade);
        }

        // /api/trades?trader=fred
        [HttpGet]
        public string Get(string trader)
        {
            return "GET for trader " + trader;
        }
    }
}
