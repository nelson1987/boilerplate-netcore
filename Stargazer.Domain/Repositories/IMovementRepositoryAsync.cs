using Stargazer.Domain.Features.Movements;

namespace Stargazer.Domain.Repositories;
public interface IGenericRepositoryAsync<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task<List<T>> GetAsync(CancellationToken cancellationToken = default);

    Task<T?> GetAsync(string id, CancellationToken cancellationToken = default);
}
public interface IMovementRepositoryAsync : IGenericRepositoryAsync<Movement>
{
    Task UpdateStatusAsync(string id, MovementStatus newMovementStatus, CancellationToken cancellationToken = default);
}
