using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AcaiStoreApi.Models
{
    [BsonIgnoreExtraElements]
    public class Acai
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Flavor { get; set; } = null!;

        public string Size { get; set; } = null!;

        public string? Optional { get; set; }
        
        [BsonElement("Name")]
        public string Email { get; set; } = null!;

    }
}
