using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockFighter
{
    public class StockFighterFactory
    {
        private HttpClient Client = null;
        
        public StockFighterFactory(string authorization)
        {
            this.Client = new HttpClient();
            this.Client.BaseAddress = new Uri(@"https://api.stockfighter.io");
            this.Client.DefaultRequestHeaders.Add(
                            "X-Starfighter-Authorization", authorization);

            Initialize();
        }

        private void Initialize()
        {
            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
                settings.NullValueHandling = NullValueHandling.Ignore;
                return settings;
            });
        }

        public Venue GetVenue(string venueSymbol)
        {
            var venue = new Venue(venueSymbol, this.Client);
            return venue;
        }
    }
}
