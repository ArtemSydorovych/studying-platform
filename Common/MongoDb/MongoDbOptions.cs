using Common.Configurations;
using Common.Configurations.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Common.MongoDb;

public class MongoDbOptions : IMongoDbOptions
{
    private const string SectionName = "MongoDb";

    public string ConnectionString { get; init; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;

    public static MongoDbOptions From(IConfiguration configuration)
    {
        var options = configuration.FromRequired<MongoDbOptions>(SectionName);
        options.Validate();

        return options;
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            throw new MissingConfigurationException(nameof(ConnectionString));
        }

        if (string.IsNullOrWhiteSpace(DatabaseName))
        {
            throw new MissingConfigurationException(nameof(DatabaseName));
        }
    }
}