using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure.Bases;
public interface IProducer<T> where T : AuditableBaseEvent
{
    Task Send(T @event, CancellationToken cancellationToken = default);
}

public class Producer<T> : IProducer<T> where T : AuditableBaseEvent
{
    private readonly IBus _producer;
    private readonly ILogger<Producer<T>> _logger;

    public Producer(IBus producer, ILogger<Producer<T>> logger)
    {
        _producer = producer;
        _logger = logger;
    }

    public async Task Send(T @event, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Mensagem a ser produzida {nameof(@event)}.");
        await _producer.Publish(@event, cancellationToken);
        _logger.LogInformation($"Mensagem produzida {nameof(@event)}.");
    }
}