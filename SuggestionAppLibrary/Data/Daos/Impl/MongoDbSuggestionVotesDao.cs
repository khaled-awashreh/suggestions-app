using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoDbSuggestionVotesDao: ISuggestionVotesDao
{
    private readonly IMongoCollection<SuggestionVotes> _suggestionVotes;

    
    public async Task<SuggestionVotes> GetVotesBySuggestionId(string suggestionId)
    {
        var results = await _suggestionVotes.FindAsync(sv => sv.SuggestionId == suggestionId);
        return results.FirstOrDefault();
    }

    public Task SaveVotesForSuggestion(SuggestionVotes voteses)
    {
        var filter = Builders<SuggestionVotes>.Filter.Eq(sv =>sv.SuggestionId, voteses.SuggestionId);
        return _suggestionVotes.ReplaceOneAsync(filter, voteses, new ReplaceOptions() { IsUpsert = true });
    }
    
}