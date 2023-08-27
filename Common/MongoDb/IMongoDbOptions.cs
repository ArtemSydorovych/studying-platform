namespace Common.MongoDb;

public interface IMongoDbOptions
{
    string ConnectionString { get; }
    string DatabaseName { get; }
}
