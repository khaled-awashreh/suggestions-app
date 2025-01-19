using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoSuggestionStatusDao : ISuggestionStatusDao
{
    private readonly IMongoCollection<SuggestionStatus> _statuses;
    private readonly IMemoryCache _cache;
    private const string _cacheKey = "suggestion_status_data";
    public async Task<List<SuggestionStatus>> GetStatusesAsync()
    {
        var output = _cache.Get<List<SuggestionStatus>>(_cacheKey);
        if (output == null)
        {
            var results = await _statuses.FindAsync(_ => true);
            output = results.ToList();
            _cache.Set(_cacheKey, _statuses, DateTimeOffset.Now.AddDays(1));
        }
        
        return output.ToList();
    }

    public async Task<SuggestionStatus> GetById(string id)
    {
        var results =  await _statuses.FindAsync(s=>s.Id==id);
        return results.FirstOrDefault();
    }

    public Task Save(SuggestionStatus status)
    {
        return _statuses.InsertOneAsync(status);
    }

    public Task Update(SuggestionStatus status)
    {
        var filter = Builders<SuggestionStatus>.Filter.Eq(s => s.Id, status.Id);
        return _statuses.ReplaceOneAsync(filter, status, new ReplaceOptions { IsUpsert = true });
    }
}