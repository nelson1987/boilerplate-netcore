using Microsoft.Extensions.Logging;
using Stargazer.Domain.Entities;
using Stargazer.Infrastructure.Persistence.Repositories;

namespace Stargazer.Infrastructure.Consumers;

public interface IMovementConsumerAsync : IConsumer<MovementCreatedEvent>
{
}

public class MovementConsumerAsync : Consumer<MovementCreatedEvent>, IMovementConsumerAsync
{
    private readonly IMovementRepositoryAsync _writeRepository;
    public MovementConsumerAsync(ILogger<Consumer<MovementCreatedEvent>> logger, IMovementRepositoryAsync writeRepository) : base(logger)
    {
        _writeRepository = writeRepository;
    }

    public override async Task Execute(MovementCreatedEvent @event)
    {
        await _writeRepository.UpdateStatusAsync(@event.Id, Status.Created);
    }
}