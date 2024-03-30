using MongoDB.Bson;

namespace Stargazer.Domain.Bases;

public abstract class AuditableBaseEntity
{
    public ObjectId Id { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public required string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}

public abstract class AuditableBaseEvent
{
    public ObjectId Id { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public required string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}

public class MailSettings
{
    public required string Subject { get; set; }
}