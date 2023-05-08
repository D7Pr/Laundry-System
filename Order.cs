using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Laundry_System
{
    public class Order
    {
        [BsonElement("CustomerId")]
        public string CustomerId { get; set; }

        public DateTime OrderDateTime { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public string OrderTotal { get; set; }
    }
}