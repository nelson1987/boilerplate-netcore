using Stargazer.Domain.Bases;

namespace Stargazer.Domain.Entities;

public class Movement : AuditableBaseEntity
{
    public decimal Valor { get; init; }
    public Status Status { get; init; }
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
    public string Conta { get; set; }

    public static implicit operator MovementCreatedEvent(Movement v)
    {
        return new Movement
        {
            Valor = v.Valor,
            Status = v.Status
        };
    }
}