using System.Reflection;
using DisabilityInPortal.ApplicationLayer.Authorization.Extensions.DependencyInjection;
using DisabilityInPortal.ApplicationLayer.Common.Behaviours;
using DisabilityInPortal.ApplicationLayer.Common.Factories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Factories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.ApplicationLayer.Common.Services;
using DisabilityInPortal.Domain.Models.Email;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DisabilityInPortal.ApplicationLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<IDocumentFileService, DocumentFileService>();
        services.AddScoped<IBlobNameProvider, BlobNameProvider>();
        services.AddScoped<IDocumentDependentEntityUpdater, DocumentDependentEntityUpdater>();

        services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));
        services.AddSingleton<IEmailRequestFactory, EmailRequestFactory>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddDomainAuthorization();
    }

    private static IServiceCollection AddDomainAuthorization(this IServiceCollection services)
    {
        services
            .AddMediatorAuthorization(Assembly.GetExecutingAssembly())
            .AddAuthorizersFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}