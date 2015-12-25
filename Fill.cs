using Newtonsoft.Json;
using System;

namespace StockFighter
{
    public class Fill
    {
        public int Price;

        [JsonProperty(PropertyName = "qty")]
        public int Quantity;

        [JsonProperty(PropertyName = "ts")]
        public DateTime TimeStamp;
    }
}