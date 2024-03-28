using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure;
public interface IProducer<T> where T : AuditableBaseEvent
{
    Task Send(T @event, CancellationToken cancellationToken = default);
}

public class Producer<T> : IProducer<T> where T : AuditableBaseEvent
{
    public Task Send(T @event, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}