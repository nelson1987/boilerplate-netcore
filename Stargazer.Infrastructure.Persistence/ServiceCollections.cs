using Microsoft.Extensions.DependencyInjection;
using Stargazer.Infrastructure.Persistence.Repositories;

namespace Stargazer.Infrastructure.Persistence;

public static class ServiceCollections
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IMovementRepositoryAsync, MovementRepositoryAsync>();
        services.AddTransient(typeof(IConsumer<>), typeof(Consumer<>));
        services.AddTransient(typeof(IProducer<>), typeof(Producer<>));
        services.AddTransient(typeof(IMailSender), typeof(MailSender));
        services.AddTransient(typeof(IHttpExternalServiceClient), typeof(HttpExternalServiceClient));
        return services;
    }
}