using Microsoft.Extensions.DependencyInjection;
using Stargazer.Infrastructure.Consumers;
using Stargazer.Infrastructure.Persistence;
using Stargazer.Infrastructure.Persistence.Repositories;
using Stargazer.Infrastructure.Producers;

namespace Stargazer.Infrastructure;

public static class ServiceCollections
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IMovementRepositoryAsync, MovementRepositoryAsync>();
        services.AddTransient(typeof(IConsumer<>), typeof(Consumer<>));
        services.AddTransient<IMovementConsumerAsync, MovementConsumerAsync>();
        services.AddTransient(typeof(IProducer<>), typeof(Producer<>));
        services.AddTransient<IMovementProducerAsync, MovementProducerAsync>();
        services.AddTransient(typeof(IMailSender), typeof(MailSender));
        services.AddTransient(typeof(IHttpExternalServiceClient), typeof(HttpExternalServiceClient));
        return services;
    }
}