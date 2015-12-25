using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace StockFighter
{
    public class OrderStatus
    {
        public bool Ok { get; set; }
        public string Symbol { get; set; }
        public string Venue { get; set; }

        public Direction Direction { get; set; }

        [JsonProperty(PropertyName = "originalQty")]
        public int OriginalQuantity { get; set; }

        [JsonProperty(PropertyName = "qty")]
        public int Quantity { get; set; }

        public int Price { get; set; }

        public OrderType Type { get; set; }

        public int Id { get; set; }

        public string Account { get; set; }

        [JsonProperty(PropertyName = "ts")]
        public DateTime? TimeStamp {get; set;}

        public List<Fill> Fills { get; set; }

        public int TotalFilled { get; set; }

        public bool Open { get; set; }
    }
}