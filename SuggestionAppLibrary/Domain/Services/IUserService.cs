namespace SuggestionAppLibrary.Domain.Services;

public interface IUserService
{
    public Task<List<User>> GetUsersAsync();

    public Task<User> GetById(string id);

    public Task<User> GetByAuthenticationId(string objectId);

    public Task Save(User user);
}