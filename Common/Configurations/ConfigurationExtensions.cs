using Common.Configurations.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Common.Configurations;

public static class ConfigurationExtensions
{
    private static T? From<T>(this IConfiguration configuration, string sectionName) where T : class =>
        configuration.GetSection(sectionName).Get<T>();

    public static T FromRequired<T>(this IConfiguration configuration, string sectionName) where T : class
    {
        T? options;

        try
        {
            options = configuration.From<T>(sectionName);
        }
        catch (Exception ex)
        {
            throw new InvalidConfigurationException(sectionName, ex);
        }

        return options ?? throw new MissingConfigurationException(sectionName);
    }
}