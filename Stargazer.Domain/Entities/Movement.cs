using Stargazer.Domain.Bases;

namespace Stargazer.Domain.Entities;

public class Movement : AuditableBaseEntity
{
    public decimal Valor { get; init; }
    public Status Status { get; init; }
    public required string Conta { get; set; }

    public MovementCreatedEvent MapToEvent()
    {
        return new MovementCreatedEvent
        {
            Id = Id,
            Conta = Conta,
            Valor = Valor,
            Status = Status,
            CreatedBy = CreatedBy,
            Created = Created,
            LastModified = LastModified,
            LastModifiedBy = LastModifiedBy,
        };
    }
}

public enum Status
{
    Pending = 1,
    Rejected = 2,
    Created = 3
}

public class MovementCreatedEvent : AuditableBaseEvent
{
    public decimal Valor { get; set; }
    public Status Status { get; set; }
    public required string Conta { get; set; }
}