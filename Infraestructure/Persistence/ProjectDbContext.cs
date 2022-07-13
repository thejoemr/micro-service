using MongoDB.Driver;

public class ProjectDbContext : MongoDbContext
{
    public ProjectDbContext() : base("proyecto")
    {
        
    }

    public IMongoCollection<UserCredentials> UserCredentialsRecord
    {
        get
        {
            return DataBase.GetCollection<UserCredentials>("user_credential");
        }
    }
}