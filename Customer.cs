using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Laundry_System
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [BsonIgnoreIfNull]
        public List<Order> Orders { get; set; }
    }
}