namespace Stargazer.Infrastructure.Persistence;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    public Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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