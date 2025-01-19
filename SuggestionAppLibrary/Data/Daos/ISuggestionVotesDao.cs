namespace SuggestionAppLibrary.DataAccess;

public interface ISuggestionVotesDao
{
    public Task<SuggestionVotes> GetVotesBySuggestionId(string suggestionId);
    
    public Task SaveVotesForSuggestion(SuggestionVotes voteses);
}