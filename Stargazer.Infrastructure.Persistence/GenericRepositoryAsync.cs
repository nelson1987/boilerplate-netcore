using MongoDB.Driver;

namespace Stargazer.Infrastructure.Persistence;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task<List<T>> GetAsync(CancellationToken cancellationToken = default);

    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    private MongoClient client = new MongoClient("mongodb://root:password@localhost:27017/");

    [Obsolete]
    public async Task? CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        IMongoDatabase db = client.GetDatabase("warehouse");
        IMongoCollection<T> Collection = db.GetCollection<T>("collectionV4");

        //        var options = new CreateIndexOptions
        //        {
        //            Unique = true,
        //            Name = $"{"collectionV4"}_{"ID"}"
        //        };
        //#pragma warning disable CS0618 // Type or member is obsolete
        //        var createdIndexName = Collection.Indexes.CreateOne($"{{ {"_id"} : 1 }}", options);
        //#pragma warning restore CS0618 // Type or member is obsolete

        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task<List<T>> GetAsync(CancellationToken cancellationToken = default)
    {
        //return await Collection.Find(_ => true).ToListAsync(cancellationToken);
        throw new NotImplementedException();
    }

    public async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        //return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        throw new NotImplementedException();
    }
}