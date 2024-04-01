using Stargazer.Domain.Bases;

namespace Stargazer.Domain.Features.Movements;

public class Movement : AuditableBaseEntity
{
    public decimal Valor { get; init; }
    public MovementStatus MovementStatus { get; init; }
    public required string Conta { get; set; }

    public MovementCreatedEvent MapToEvent()
    {
        return new MovementCreatedEvent
        {
            Id = Id,
            Conta = Conta,
            Valor = Valor,
            MovementStatus = MovementStatus,
            CreatedBy = CreatedBy,
            Created = Created,
            LastModified = LastModified,
            LastModifiedBy = LastModifiedBy,
        };
    }
}
