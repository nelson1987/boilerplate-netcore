using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stargazer.Domain.Bases;

public record RabbitMqOptions(string server, string user, string password);

public record MongoDbOptions(string server, string user, string password);
public abstract class AuditableBaseEntity
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public required string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}

public abstract class AuditableBaseEvent
{
    public string Id { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public required string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}

public class MailSettings
{
    public required string Subject { get; set; }
}