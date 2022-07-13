using MongoDB.Driver;

public class UserCredentialsService
{
    private IMongoCollection<UserCredentials> collection;

    public UserCredentialsService(ProjectDbContext dbContext)
    {
        collection = dbContext.UserCredentialsRecord;
    }

    public async Task<IEnumerable<UserCredentials>> GetAsync() => await collection.Find(_ => true).ToListAsync();

    public async Task<UserCredentials?> GetAsync(string id) => await collection.Find(x => x.CredentialId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(UserCredentials credentials) => await collection.InsertOneAsync(credentials);

    public async Task UpdateAsync(string id, UserCredentials credentials) => await collection.ReplaceOneAsync(x => x.CredentialId == id, credentials);

    public async Task RemoveAsync(string id) => await collection.DeleteOneAsync(x => x.CredentialId == id);
}