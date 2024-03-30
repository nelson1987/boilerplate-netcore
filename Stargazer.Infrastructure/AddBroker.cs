using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Stargazer.Domain.Entities;

namespace Stargazer.Infrastructure;
public static class Services
{
    public static void AddBroker(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumer<Consumer<MovementCreatedEvent>>();
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("amqp://guest:guest@localhost:5672");
                cfg.ConfigureEndpoints(ctx);
                //cfg.UseRawJsonSerializer();
            });
        });
    }
}
