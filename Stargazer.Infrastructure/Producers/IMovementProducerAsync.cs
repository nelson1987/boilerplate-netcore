using Stargazer.Domain.Entities;

namespace Stargazer.Infrastructure.Producers;
public interface IMovementProducerAsync : IProducer<MovementEvent>
{
}

public class MovementProducerAsync : Producer<MovementEvent>, IMovementProducerAsync
{
}