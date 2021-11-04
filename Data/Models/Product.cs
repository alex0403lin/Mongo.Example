using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public class Product : BaseModel
    {
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("price")]
        public int Price { get; set; }
    }
}