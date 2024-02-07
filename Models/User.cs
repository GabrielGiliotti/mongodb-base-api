using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_base_api.Models;

public class User : Default
{
    [BsonElement("Name")]
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}