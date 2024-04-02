using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stargazer.Domain.Bases;
using Stargazer.Domain.Broker;
using Stargazer.Domain.Repositories;
using Stargazer.Infrastructure.Bases;
using Stargazer.Infrastructure.Broker;
using Stargazer.Infrastructure.Broker.Configurations;
using Stargazer.Infrastructure.Broker.Consumers;
using Stargazer.Infrastructure.Broker.Producers;
using Stargazer.Infrastructure.Persistence;
using Stargazer.Infrastructure.Persistence.Repositories;

namespace Stargazer.Infrastructure;

public static class ServiceCollections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        var mongoDbConn = configuration.GetSection("ConnectionStrings:MongoDb");
        var broker = configuration.GetSection("Broker");
        var rabbitMqOptions = new RabbitMqOptions(broker["server"]!, broker["user"]!, broker["password"]!);
        var mongoDbOptions = new MongoDbOptions(mongoDbConn["server"]!, mongoDbConn["user"]!, mongoDbConn["password"]!);

        services.AddSingleton(mongoDbOptions);
        services.AddTransient(typeof(IMailSender), typeof(MailSender));
        services.AddTransient(typeof(IHttpExternalServiceClient), typeof(HttpExternalServiceClient));
        services.AddRepositories()
            .AddBroker(rabbitMqOptions)
            .AddConsumers()
            .AddProducers();
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
        services.AddTransient(typeof(IGenericConsumer<>), typeof(GenericConsumer<>));
        services.AddTransient<IMovementConsumerAsync, MovementConsumerAsync>();
        return services;
    }

    private static IServiceCollection AddProducers(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericProducer<>), typeof(GenericProducer<>));
        services.AddTransient<IMovementProducerAsync, MovementProducerAsync>();
        return services;
    }

    private static IServiceCollection AddBroker(this IServiceCollection services, RabbitMqOptions options)
    {
        services.AddRabbitmqBroker(options);
        return services;
    }
}