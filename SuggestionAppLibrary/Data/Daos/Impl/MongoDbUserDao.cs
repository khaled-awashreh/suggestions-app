namespace SuggestionAppLibrary.DataAccess;

public class MongoDbUserDao : IUserDao
{
    private readonly IMongoCollection<User> _users;

    public MongoDbUserDao(IDbConnection db)
    {
        _users = db.UserCollection;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var results = await _users.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<User> GetById(string id)
    {
        var results = await _users.FindAsync(user => user.Id == id);
        return results.FirstOrDefault();
    }

    public async Task<User> GetByAuthenticationId(string objectId)
    {
        var results = await _users.FindAsync(user => user.ObjectIdentifier == objectId);
        return results.FirstOrDefault();
    }

    public Task Save(User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions() { IsUpsert = true });
        
    }
}