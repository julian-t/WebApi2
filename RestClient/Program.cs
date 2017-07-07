using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

// Very simple console REST client

namespace RestClient
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

    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            // Set the base address, and tell the server to send JSON
            client.BaseAddress = new Uri("http://localhost:50328/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Console.WriteLine("Single trade:");
                // Get a single trade
                HttpResponseMessage response = await client.GetAsync("/api/trades/3");
                if (response.IsSuccessStatusCode)
                {
                    var t1 = await response.Content.ReadAsAsync<Trade>();

                    if (t1 != null)
                        Console.WriteLine($"{t1.Symbol}");
                    else
                        Console.WriteLine("Null trade");
                }

                // Get all the trades as a collection
                Console.WriteLine("All trades:");

                response = await client.GetAsync("/api/trades");
                if (response.IsSuccessStatusCode)
                {
                    var all_trades = await response.Content.ReadAsAsync<IList<Trade>>();
                    if (all_trades == null)
                        Console.WriteLine("all_trades is null");
                    else
                    {
                        foreach (var t in all_trades)
                        {
                            Console.WriteLine($"{t.Symbol}");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
