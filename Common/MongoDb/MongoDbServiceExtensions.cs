using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.MongoDb;

public static class MongoDbServiceExtensions
{
    public static void AddMongoDbService(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDbOptions = MongoDbOptions.From(configuration);

        services.AddSingleton<IMongoDbOptions>(mongoDbOptions);
    }
} 