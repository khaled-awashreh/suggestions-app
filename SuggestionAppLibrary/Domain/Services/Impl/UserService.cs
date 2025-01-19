namespace SuggestionAppLibrary.Domain.Services.Impl;

public class UserService:IUserService
{
    private readonly IUserDao _userDao;
    public Task<List<User>> GetUsersAsync()
    {
        return _userDao.GetUsersAsync();
    }

    public Task<User> GetById(string id)
    {
        return _userDao.GetById(id);
    }

    public Task<User> GetByAuthenticationId(string objectId)
    {
        return _userDao.GetByAuthenticationId(objectId);
    }

    public Task Save(User user)
    {
        return _userDao.Save(user);
    }
}