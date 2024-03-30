using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Entities;

namespace Stargazer.Infrastructure.Producers;
public interface IMovementProducerAsync : IProducer<MovementCreatedEvent>
{
}

public class MovementProducerAsync : Producer<MovementCreatedEvent>, IMovementProducerAsync
{
    public MovementProducerAsync(IBus producer, ILogger<Producer<MovementCreatedEvent>> logger) : base(producer, logger)
    {
    }
}