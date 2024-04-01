using Microsoft.Extensions.DependencyInjection;
using Stargazer.Infrastructure.Bases;
using Stargazer.Infrastructure.Configurations;
using Stargazer.Infrastructure.Consumers;
using Stargazer.Infrastructure.Persistence;
using Stargazer.Infrastructure.Persistence.Repositories;
using Stargazer.Infrastructure.Producers;

namespace Stargazer.Infrastructure;

public static class ServiceCollections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient(typeof(IMailSender), typeof(MailSender));
        services.AddTransient(typeof(IHttpExternalServiceClient), typeof(HttpExternalServiceClient));
        services.AddRepositories()
            .AddConsumers()
            .AddProducers()
            .AddBroker();
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IMovementRepositoryAsync, MovementRepositoryAsync>();
        return services;
    }

    private static IServiceCollection AddConsumers(this IServiceCollection services)
    {
        services.AddTransient(typeof(IConsumer<>), typeof(Consumer<>));
        services.AddTransient<IMovementConsumerAsync, MovementConsumerAsync>();
        return services;
    }

    private static IServiceCollection AddProducers(this IServiceCollection services)
    {
        services.AddTransient(typeof(IProducer<>), typeof(Producer<>));
        services.AddTransient<IMovementProducerAsync, MovementProducerAsync>();
        return services;
    }

    private static IServiceCollection AddBroker(this IServiceCollection services)
    {
        services.AddRabbitmqBroker();
        return services;
    }
}