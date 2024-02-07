using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_base_api.Models;

public class Default
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}