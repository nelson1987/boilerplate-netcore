using MassTransit;
using Microsoft.Extensions.Logging;
using Stargazer.Domain.Broker;
using Stargazer.Domain.Features.Movements;

namespace Stargazer.Infrastructure.Broker.Producers;
public interface IMovementProducerAsync : IGenericProducer<MovementCreatedEvent>
{
}

public class MovementProducerAsync : GenericProducer<MovementCreatedEvent>, IMovementProducerAsync
{
    public MovementProducerAsync(IBus producer, ILogger<GenericProducer<MovementCreatedEvent>> logger) : base(producer, logger)
    {
    }
}