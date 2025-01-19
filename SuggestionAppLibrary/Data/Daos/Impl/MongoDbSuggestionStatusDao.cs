using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoDbSuggestionStatusDao : ISuggestionStatusDao
{
    private readonly IMongoCollection<SuggestionStatus> _statuses;
    private readonly IMemoryCache _cache;
    private const string _cacheKey = "suggestion_status_data";

    public async Task<List<SuggestionStatus>> GetAllStatusesAsync()
    {
        var output = _cache.Get<List<SuggestionStatus>>(_cacheKey);
        if (output == null)
        {
            var results = await _statuses.FindAsync(_ => true);
            output = results.ToList();
            _cache.Set(_cacheKey, _statuses, TimeSpan.FromDays(1));
        }

        return output.ToList();
    }

    public async Task<SuggestionStatus> GetById(string id)
    {
        var results = await _statuses.FindAsync(s => s.Id == id);
        return results.FirstOrDefault();
    }

    public Task Save(SuggestionStatus status)
    {
        var filter = Builders<SuggestionStatus>.Filter.Eq(s => s.Id, status.Id);
        var operation = _statuses.ReplaceOneAsync(filter, status, new ReplaceOptions { IsUpsert = true });
        _cache.Remove(_cacheKey);
        return operation;
    }
}