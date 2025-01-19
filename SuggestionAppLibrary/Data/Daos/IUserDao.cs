namespace SuggestionAppLibrary.DataAccess;

public interface IUserDao
{
    public Task<List<User>> GetUsersAsync();

    public Task<User> GetById(string id);

    public Task<User> GetByAuthenticationId(string objectId);

    public Task Save(User user);
    
}