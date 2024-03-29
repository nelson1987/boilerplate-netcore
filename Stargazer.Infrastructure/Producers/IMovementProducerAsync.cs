using Stargazer.Domain.Entities;

namespace Stargazer.Infrastructure.Producers;
public interface IMovementProducerAsync : IProducer<MovementCreatedEvent>
{
}

public class MovementProducerAsync : Producer<MovementCreatedEvent>, IMovementProducerAsync
{
}