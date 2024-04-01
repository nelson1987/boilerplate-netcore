using Stargazer.Domain.Bases;

namespace Stargazer.Domain.Features.Movements;

public class Movement : AuditableBaseEntity
{
    public decimal Valor { get; init; }
    public MovementStatus Status { get; init; }
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
