using MongoDB.Driver;

public abstract class MongoDbContext
{
    public MongoDbContext(string database)
    {
        var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
        var mongoClient = new MongoClient(connectionString);
        DataBase = mongoClient.GetDatabase(database);
    }

    protected IMongoDatabase DataBase { get; }
}