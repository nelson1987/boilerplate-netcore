using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Stargazer.Domain.Bases;

namespace Stargazer.Infrastructure.Persistence;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task<List<T>> GetAsync(CancellationToken cancellationToken = default);

    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : AuditableBaseEntity
{
    private readonly ILogger<GenericRepositoryAsync<T>> _logger;
    public GenericRepositoryAsync(ILogger<GenericRepositoryAsync<T>> logger)
    {
        _logger = logger;
    }
    private MongoClient client = new MongoClient("mongodb://root:password@localhost:27017/");

    [Obsolete]
    public async Task? CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("CreateAsync");
        IMongoDatabase db = client.GetDatabase("warehouse");
        IMongoCollection<T> Collection = db.GetCollection<T>("collectionV4");
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task<List<T>> GetAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("GetAsync");
        IMongoDatabase db = client.GetDatabase("warehouse");
        IMongoCollection<T> Collection = db.GetCollection<T>("collectionV4");
        return await Collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        //IMongoDatabase db = client.GetDatabase("warehouse");
        //IMongoCollection<T> Collection = db.GetCollection<T>("collectionV4");
        //return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        throw new NotImplementedException();
    }
}