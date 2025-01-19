namespace SuggestionAppLibrary.Domain.Services.Impl;

public class SuggestionStatusService : ISuggestionStatusService
{
    ISuggestionStatusDao _suggestionStatusDao;

    public Task<List<SuggestionStatus>> GetAllStatusesAsync()
    {
        return _suggestionStatusDao.GetAllStatusesAsync();
    }

    public Task<SuggestionStatus> GetById(string id)
    {
        return _suggestionStatusDao.GetById(id);
    }

    public Task Save(SuggestionStatus status)
    {
        return _suggestionStatusDao.Save(status);
    }
}