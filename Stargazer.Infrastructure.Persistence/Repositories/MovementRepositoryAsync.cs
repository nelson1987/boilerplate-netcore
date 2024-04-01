using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Stargazer.Domain.Features.Movements;

namespace Stargazer.Infrastructure.Persistence.Repositories;

public interface IMovementRepositoryAsync : IGenericRepositoryAsync<Movement>
{
    Task UpdateStatusAsync(string id, MovementStatus newMovementStatus, CancellationToken cancellationToken = default);
}

public class MovementRepositoryAsync : GenericRepositoryAsync<Movement>, IMovementRepositoryAsync
{
    private readonly ILogger<GenericRepositoryAsync<Movement>> _logger;

    public MovementRepositoryAsync(ILogger<GenericRepositoryAsync<Movement>> logger) : base(logger)
    {
        _logger = logger;
    }

    public async Task UpdateStatusAsync(string id, MovementStatus newMovementStatus, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("UpdateStatusAsync");
        MongoClient client = new MongoClient("mongodb://root:password@localhost:27017/");
        IMongoDatabase db = client.GetDatabase("warehouse");
        IMongoCollection<Movement> Collection = db.GetCollection<Movement>("collectionV4");
        var filter = Builders<Movement>.Filter.Eq(x => x.Id, id);
        var update = Builders<Movement>.Update
            .Set(x => x.MovementStatus, newMovementStatus)
            .Set(x => x.LastModified, DateTime.Now)
            .Set(x => x.LastModifiedBy, "Consumer");
        await Collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }
}