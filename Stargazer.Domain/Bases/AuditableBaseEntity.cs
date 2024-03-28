namespace Stargazer.Domain.Bases;

public abstract class AuditableBaseEntity
{
    public virtual int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}

public abstract class AuditableBaseEvent
{
    public virtual int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}

public class MailSettings
{
    public string Subject { get; set; }
}