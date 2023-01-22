using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoExample.Models;

public class Product {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}

    public string name {get; set; } = null!;

    [BsonElement("sizes")]
    [JsonPropertyName("sizes")]
    public List<string> sizes {get; set;} = null!;
}