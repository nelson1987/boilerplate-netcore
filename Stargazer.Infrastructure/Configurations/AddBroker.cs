using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Stargazer.Infrastructure.Consumers;

namespace Stargazer.Infrastructure.Configurations;
public static class Services
{
    public static IServiceCollection AddRabbitmqBroker(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
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
