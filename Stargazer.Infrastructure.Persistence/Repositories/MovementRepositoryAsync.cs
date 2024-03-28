using Stargazer.Domain.Entities;

namespace Stargazer.Infrastructure.Persistence.Repositories;

public interface IMovementRepositoryAsync : IGenericRepositoryAsync<Movement>
{
    Task<bool> IsWarming();
}

public class MovementRepositoryAsync : GenericRepositoryAsync<Movement>, IMovementRepositoryAsync
{
    public Task<bool> IsWarming()
    {
        throw new NotImplementedException();
    }
}