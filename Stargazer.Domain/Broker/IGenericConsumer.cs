using Stargazer.Domain.Bases;

namespace Stargazer.Domain.Broker;

public interface IGenericConsumer<T>
{
    //Task Consume(T context);
}

public interface IGenericProducer<T> where T : AuditableBaseEvent
{
    Task Send(T @event, CancellationToken cancellationToken = default);
}