using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Bases;
using Stargazer.Domain.Broker;

namespace Stargazer.Infrastructure.Broker;

public class GenericProducer<T> : IGenericProducer<T> where T : AuditableBaseEvent
{
    private readonly IBus _producer;
    private readonly ILogger<GenericProducer<T>> _logger;

    public GenericProducer(IBus producer, ILogger<GenericProducer<T>> logger)
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