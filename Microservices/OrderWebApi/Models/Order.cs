using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderWebApi.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        [BsonElement("customer_id"), BsonRepresentation(BsonType.Int32)]
        public int CustomerId { get; set; }
        [BsonElement("order_on"), BsonRepresentation(BsonType.DateTime)]
        public DateTime OrderOn { get; set; }
        
        // public List<OrderDetail> OrderDetails { get; set; }
    }
}