using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CourseworkAPI.Models;

public class Player
{ 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("username")] public string Username { get; set; } = null!;
    
    [BsonElement("highScore")] public int HighScore { get; set; }
}