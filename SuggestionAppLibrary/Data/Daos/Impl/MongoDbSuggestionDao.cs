using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoDbSuggestionDao : ISuggestionDao
{
    private readonly IMongoCollection<Suggestion> _suggestions;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "suggestions";

    public MongoDbSuggestionDao(DbConnection db, IMemoryCache cache)
    {
        _suggestions = db.SuggestionCollection;
        _cache = cache;
    }

    public async Task<List<Suggestion>> GetAllSuggestionsAsync()
    {
        var output = _cache.Get<List<Suggestion>>(_cache);
        if (output == null)
        {
            var results = await _suggestions.FindAsync(_ => true);
            _cache.Set(CacheKey, results, TimeSpan.FromMinutes(1));
            output = await results.ToListAsync();
        }

        return output.ToList();
    }

    public async Task<List<Suggestion>> GetAllApprovedForReleaseSuggestionsAsync()
    {
        var output = await _suggestions.FindAsync(s => s.ApprovedForRelease == true);

        return output.ToList();
    }

    public async Task<List<Suggestion>> GetAllAwaitingForApprovalSuggestionsAsync()
    {
        var output = await _suggestions.FindAsync(s => s.ApprovedForRelease != true
                                                       && s.Rejected == false);

        return output.ToList();
    }

    public async Task<List<Suggestion>> GetAllRejectedSuggestionsAsync()
    {
        var output = await _suggestions.FindAsync(s => s.Rejected == false);

        return output.ToList();
    }

    public async Task<Suggestion> GetById(string id)
    {
        var results = await _suggestions.FindAsync(u => u.Id == id);
        return await results.FirstOrDefaultAsync();
    }

    public Task Save(Suggestion suggestion)
    {
        var filters = Builders<Suggestion>.Filter.Eq(u => u.Id, suggestion.Id);
        var operation = _suggestions.ReplaceOneAsync(filters, suggestion, new UpdateOptions { IsUpsert = true });
        _cache.Remove(CacheKey);
        return operation;
    }
}