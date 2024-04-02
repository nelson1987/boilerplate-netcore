using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Bases;
using Stargazer.Domain.Broker;

namespace Stargazer.Infrastructure.Broker;

public class GenericConsumer<T> : IConsumer<T>, IGenericConsumer<ConsumeContext<T>> where T : AuditableBaseEvent
{
    private readonly ILogger<GenericConsumer<T>> _logger;

    public GenericConsumer(ILogger<GenericConsumer<T>> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<T> context)
    {
        _logger.LogInformation($"Mensagem consumida started: {nameof(context.Message)}.");
        var @event = context.Message;
        await Execute(@event);
        _logger.LogInformation($"Mensagem consumida ended: {nameof(@event)}.");
    }

    public virtual async Task Execute(T @event)
    {
        await Task.CompletedTask;
    }
}