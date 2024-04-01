using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Stargazer.Domain.Bases;
using Stargazer.Domain.Features.Movements;

namespace Stargazer.Infrastructure.Persistence.Repositories;

public interface IMovementRepositoryAsync : IGenericRepositoryAsync<Movement>
{
    Task UpdateStatusAsync(string id, MovementStatus newMovementStatus, CancellationToken cancellationToken = default);
}

public class MovementRepositoryAsync : GenericRepositoryAsync<Movement>, IMovementRepositoryAsync
{
    private readonly ILogger<GenericRepositoryAsync<Movement>> _logger;

    public MovementRepositoryAsync(ILogger<GenericRepositoryAsync<Movement>> logger, MongoDbOptions dbOptions) 
        : base(logger, dbOptions, "warehouse", nameof(Movement))
    {
        _logger = logger;
    }

    public async Task UpdateStatusAsync(string id, MovementStatus newMovementStatus, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("UpdateStatusAsync");
        var filter = Builders<Movement>.Filter.Eq(x => x.Id, id);
        var update = Builders<Movement>.Update
            .Set(x => x.Status, newMovementStatus)
            .Set(x => x.LastModified, DateTime.Now)
            .Set(x => x.LastModifiedBy, "Consumer");
        await Collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }
}