using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Stargazer.Domain.Bases;
using Stargazer.Infrastructure.Consumers;

namespace Stargazer.Infrastructure.Configurations;
public static class Services
{
    public static IServiceCollection AddRabbitmqBroker(this IServiceCollection services, RabbitMqOptions options)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(options.server, "/", h =>
                {
                    h.Username(options.user);
                    h.Password(options.password);
                });
                //cfg.Host("amqp://guest:guest@localhost:5672");
                cfg.ConfigureEndpoints(ctx);
                //cfg.UseRawJsonSerializer();
            });
            //x.AddConsumeObserver<ConsumeObserver>();
            //x.AddPublishObserver<PublishObserver>();
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumer<MovementConsumerAsync>();
        });
        return services;
    }
}
