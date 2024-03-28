using Microsoft.Extensions.DependencyInjection;
using Stargazer.Domain.Entities;

namespace Stargazer.Infrastructure.Persistence;
public static class ServiceCollections
{
    public static void AddPersistence(this IServiceCollection services/*, IConfiguration configuration*/)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
    }

    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> SelectAsync();
    }

    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        public Task<T> SelectAsync()
        {
            throw new NotImplementedException();
        }
    }

    public interface IProductRepositoryAsync
    {
        Task<bool> IsWarming();

    }

    public class ProductRepositoryAsync : GenericRepositoryAsync<WeatherForecast>, IProductRepositoryAsync
    {
        public Task<bool> IsWarming()
        {
            throw new NotImplementedException();
        }
    }
}