using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Stargazer.Domain.Bases;
using Stargazer.Domain.Repositories;

namespace Stargazer.Infrastructure.Persistence;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : AuditableBaseEntity
{
    private readonly ILogger<GenericRepositoryAsync<T>> _logger;
    private readonly MongoDbOptions _dbOptions;
    public IMongoCollection<T> Collection;

    public GenericRepositoryAsync(ILogger<GenericRepositoryAsync<T>> logger, MongoDbOptions dbOptions, string database, string collection)
    {
        _logger = logger;
        _dbOptions = dbOptions;
        MongoClient client = new MongoClient($"mongodb://{_dbOptions.user}:{_dbOptions.password}@{_dbOptions.server}:27017/");
        IMongoDatabase db = client.GetDatabase(database);
        Collection = db.GetCollection<T>(collection);
    }

    public async Task? CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("CreateAsync");
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task<List<T>> GetAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetAsync");
        return await Collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<T?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetByIdAsync");
        return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}