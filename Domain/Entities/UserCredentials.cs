using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class UserCredentials
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CredentialId { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}