using Microsoft.Extensions.Logging;
using Stargazer.Domain.Broker;
using Stargazer.Domain.Features.Movements;
using Stargazer.Domain.Repositories;

namespace Stargazer.Infrastructure.Broker.Consumers;

public interface IMovementConsumerAsync : IGenericConsumer<MovementCreatedEvent>
{
}

public class MovementConsumerAsync : GenericConsumer<MovementCreatedEvent>, IMovementConsumerAsync
{
    private readonly IMovementRepositoryAsync _writeRepository;
    public MovementConsumerAsync(ILogger<GenericConsumer<MovementCreatedEvent>> logger, IMovementRepositoryAsync writeRepository) : base(logger)
    {
        _writeRepository = writeRepository;
    }

    public override async Task Execute(MovementCreatedEvent @event)
    {
        await _writeRepository.UpdateStatusAsync(@event.Id, MovementStatus.Created);
    }
}