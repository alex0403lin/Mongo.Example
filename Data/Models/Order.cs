using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public class Order : BaseModel
    {
        [BsonElement("orderNumber")]
        public string OrderNumber { get; set; }
        [BsonElement("products")]
        public List<OrderItem> Products { get; set; }
    }

    public class OrderItem
    {
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("price")]
        public int Price { get; set; }
    }
}