using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public abstract class BaseModel
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
    }
}