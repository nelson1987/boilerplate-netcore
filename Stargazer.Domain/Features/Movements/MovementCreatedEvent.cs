using Stargazer.Domain.Bases;

namespace Stargazer.Domain.Features.Movements;
public class MovementCreatedEvent : AuditableBaseEvent
{
    public decimal Valor { get; set; }
    public MovementStatus Status { get; set; }
    public required string Conta { get; set; }
}
