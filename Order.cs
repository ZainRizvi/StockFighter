using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace StockFighter
{
    public enum OrderType
    {
        Limit,
        Market,
        FillOrKill,
        ImmediateOrCancel
    }

    public enum Direction
    {
        Buy,
        Sell
    }

    public class Order
    {
        public OrderType OrderType { get; set; }

        [JsonProperty(PropertyName = "qty")]
        public int Quantity { get; set; }

        public Direction Direction { get; set; }

        public string Account { get; set; }

        public Order(OrderType orderType, int quantity, Direction direction, string account)
        {
            this.OrderType = orderType;
            this.Quantity = quantity;
            this.Direction = direction;
            this.Account = account;
        }
    }
}