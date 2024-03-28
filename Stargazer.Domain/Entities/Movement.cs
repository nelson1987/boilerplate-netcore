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

public class MovementEvent : AuditableBaseEvent
{
    public decimal Valor { get; init; }
    public Status Status { get; init; }

    public static implicit operator MovementEvent(Movement v)
    {
        return new Movement
        {
            Valor = v.Valor,
            Status = v.Status
        };
    }
}