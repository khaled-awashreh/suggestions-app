namespace SuggestionAppLibrary.Domain.Services.Impl;

public class SuggestionService : ISuggestionService
{
    private readonly ISuggestionDao _suggestionDao;
    private readonly ISuggestionVotesDao _suggestionVotesDao;

    public SuggestionService(ISuggestionDao suggestionDao, ISuggestionStatusDao suggestionStatusDao,
        ISuggestionVotesDao suggestionVotesDao)
    {
        _suggestionDao = suggestionDao;
        _suggestionVotesDao = suggestionVotesDao;
    }

    public Task<List<Suggestion>> GetAllSuggestionsAsync()
    {
        return _suggestionDao.GetAllSuggestionsAsync();
    }

    public Task<Suggestion> GetById(string id)
    {
        return _suggestionDao.GetById(id);
    }

    public Task Save(Suggestion sugestion)
    {
        return _suggestionDao.Save(sugestion);
    }

    public async Task UpvoteASuggestion(string suggestionId, string userId)
    {
        var suggestionVotes = await _suggestionVotesDao.GetVotesBySuggestionId(suggestionId);
        bool isUpvote = !suggestionVotes.VotingUsers.Contains(userId);
        if (isUpvote)
        {
            suggestionVotes.VotingUsers.Add(userId);
        }
        else
        {
            suggestionVotes.VotingUsers.Remove(userId);
        }
        
        await _suggestionVotesDao.SaveVotesForSuggestion(suggestionVotes);
    }
}