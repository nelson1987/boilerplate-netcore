using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure;
public interface IConsumer<T> where T : AuditableBaseEvent
{
    //Task<AuditableBaseEvent?> Consume(CancellationToken cancellationToken = default);
    Task Consume(ConsumeContext<T> context);
}
public class Consumer<T> : MassTransit.IConsumer<T>, IConsumer<T> where T : AuditableBaseEvent
{
    //public Task<AuditableBaseEvent?> Consume(CancellationToken cancellationToken = default)
    //{
    //    throw new NotImplementedException();
    //}

    private readonly ILogger<Consumer<T>> _logger;

    public Consumer(ILogger<Consumer<T>> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<T> context)
    {
        var @event = context.Message;
        _logger.LogInformation($"Mensagem consumida {nameof(@event)}.");
        await Task.CompletedTask;
        //await _producer.Publish(@event, cancellationToken);
        //_logger.LogInformation($"Mensagem produzida {nameof(@event)}.");
    }
}