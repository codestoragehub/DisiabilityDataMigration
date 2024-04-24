using Microsoft.Extensions.Configuration;

namespace DisabilityInPortal.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    public static TConfig Get<TConfig>(this IConfiguration configuration, string sectionName)
        where TConfig : class, new()
    {
        var instance = new TConfig();

        configuration.GetSection(sectionName).Bind(instance);

        return instance;
    }
}