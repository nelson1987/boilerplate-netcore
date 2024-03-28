using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Stargazer.Application.Features.Movements;

namespace Stargazer.Application;

public static class ServiceCollections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AddMovementCommand>, AddMovementCommandValidator>();
        services.AddScoped<IAddMovementCommandHandler, AddMovementCommandHandler>();
        return services;
    }
}