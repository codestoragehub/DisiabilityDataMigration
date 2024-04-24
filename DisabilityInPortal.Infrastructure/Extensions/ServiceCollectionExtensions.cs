using System.Reflection;
using AspNetCoreRateLimit;
using Azure.Storage.Blobs;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Contexts;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Repositories;
using DisabilityInPortal.ApplicationLayer.Common.Interfaces.Services;
using DisabilityInPortal.ApplicationLayer.Common.Services;
using DisabilityInPortal.Domain.Models;
using DisabilityInPortal.Domain.Models.Email;
using DisabilityInPortal.Domain.Payments;
using DisabilityInPortal.Infrastructure.Cache;
using DisabilityInPortal.Infrastructure.Persistence;
using DisabilityInPortal.Infrastructure.Persistence.Repositories;
using DisabilityInPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Proximo.reCAPTCHA;
using Stripe;
using CapabilityService = DisabilityInPortal.ApplicationLayer.Common.Services.CapabilityService;

namespace DisabilityInPortal.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPersistenceContexts()
            .AddBlobStorageServices(configuration)
            .AddRepositories()
            .AddSharedServices(configuration)
            .AddRateLimiter(configuration)
            .AddPayments(configuration)
            .AddApplicationInsightsTelemetry()
            .AddCustomHealthChecks();
    }

    private static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
    {
        services
            .AddHealthChecks()
            .AddDbContextCheck<DisabilityInPortalDbContext>();

        return services;
    }

    private static IServiceCollection AddPersistenceContexts(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IDisabilityInPortalDbContext, DisabilityInPortalDbContext>();

        return services;
    }

    private static IServiceCollection AddBlobStorageServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(_ => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage")));
        services.AddScoped<IBlobStorageService, BlobStorageService>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.RegisterAssemblyPublicNonGenericClasses()
            .Where(c => c.Name.EndsWith("Repository"))
            .AsPublicImplementedInterfaces();

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddSharedServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IMailService, SendGridMailService>();
        services.AddSingleton<IConcurrencyService, ConcurrencyService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ISearchService, SearchService>();
        services.AddTransient<IPaymentProviderService, PaymentProviderService>();

        services.Configure<SystemSettings>(configuration.GetSection("SystemSettings"));
        services.Configure<SendGridMailSenderOptions>(configuration.GetSection("ExternalProviders:SendGrid"));
        services.AddRecaptcha(configuration.GetSection("RecaptchaSettings"));
        services.AddSingleton<MyMemoryCache>();
        services.AddTransient<ICapabilityService, CapabilityService>();
        services.AddTransient<IApplicationCloningService, ApplicationCloningService>();
        services.AddTransient<IApplicationService, ApplicationService>();
        services.AddTransient<IManagementAtOutsideFirmService, ManagementAtOutsideFirmService>();
        services.AddTransient<IBankAndCreditReferenceService, BankAndCreditReferenceService>();
        services.AddTransient<IAdditionalDocumentService, AdditionalDocumentService>();
        services.AddTransient<IAdditionalInformationService, AdditionalInformationService>();
        services.AddTransient<IFinancialSizeService, FinancialSizeService>();
        services.AddTransient<IBusinessRelationshipService, BusinessRelationshipService>();
        services.AddTransient<ILegalStructureService, LegalStructureService>();
        services.AddTransient<IDisabilityImpactDocumentService, DisabilityImpactDocumentService>();
        services.AddTransient<IContractReferenceService, ContractReferenceService>();
        services.AddTransient<ISupplierProfileService, SupplierProfileService>();
        services.AddTransient<ISupplierProfileCapabilityService, SupplierProfileCapabilityService>();

        return services;
    }

    private static IServiceCollection AddRateLimiter(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.Configure<ClientRateLimitOptions>(configuration.GetSection("ClientRateLimiting"));
        services.Configure<ClientRateLimitPolicies>(configuration.GetSection("ClientRateLimitPolicies"));
        services.AddInMemoryRateLimiting();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        return services;
    }

    private static IServiceCollection AddPayments(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PaymentsConfiguration>(configuration.GetSection("Payments"));
        var paymentsConfiguration = configuration.Get<PaymentsConfiguration>("Payments");
        StripeConfiguration.ApiKey = paymentsConfiguration.StripeConfig.SecretKey;

        return services;
    }
}