using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure;


public interface IConsumer<T> where T : AuditableBaseEvent
{
    Task Consume(ConsumeContext<T> context);
    //Task Execute(T @event);
}
public class Consumer<T> : MassTransit.IConsumer<T>, IConsumer<T> where T : AuditableBaseEvent
{
    private readonly ILogger<Consumer<T>> _logger;

    public Consumer(ILogger<Consumer<T>> logger)
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