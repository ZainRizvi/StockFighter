using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockFighter
{
    public class Venue
    {
        string Symbol;
        HttpClient Client;

        public Venue(string venueSymbol, HttpClient client)
        {
            this.Symbol = venueSymbol;
            this.Client = client;
        }

        public string GetStocks()
        {
            var path = Paths.ExpandPath(Paths.StockRoot, new Dictionary<string, string> { { Paths.PathParts.VenueName, this.Symbol } });
            var response = this.Client.GetAsync(path).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public Stock GetStock(Stock stock)
        {
            var path = Paths.ExpandPath(
                Paths.StockQuote, 
                new Dictionary<string, string> {
                    { Paths.PathParts.VenueName, this.Symbol },
                    { Paths.PathParts.StockName, stock.Symbol }
                });
            var response = this.Client.GetAsync(path).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            var returnStock = JsonConvert.DeserializeObject<Stock>(result);
            return returnStock;
        }

        public OrderStatus OrderStock(Stock stock, Order order)
        {
            var path = Paths.ExpandPath(
                Paths.StockOrder,
                new Dictionary<string, string> {
                    { Paths.PathParts.VenueName, this.Symbol },
                    { Paths.PathParts.StockName, stock.Symbol }
                });

            var purchaseOrderJson = JsonConvert.SerializeObject(order);
            var content = new StringContent(purchaseOrderJson);

            var response = this.Client.PostAsync(path, content).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            var returnOrder = JsonConvert.DeserializeObject<OrderStatus>(result);
            return returnOrder;
        }
    }
}
