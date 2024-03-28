using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure;
public interface IConsumer<T> where T : AuditableBaseEvent
{
    Task<AuditableBaseEvent?> Consume(CancellationToken cancellationToken = default);
}
public class Consumer<T> : IConsumer<T> where T : AuditableBaseEvent
{
    public Task<AuditableBaseEvent?> Consume(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}