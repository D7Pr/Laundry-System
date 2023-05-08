using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Laundry_System
{
    public class OrderItem
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string ClothesType { get; set; }
        public string Service { get; set; }
        public int Quantity { get; set; }
        public decimal ServicePrice { get; set; }

        [BsonElement("Total")]
        public decimal Total { get; set; }
    }
}