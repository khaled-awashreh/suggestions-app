using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoDbSuggestionDao : ISuggestionDao
{
    private readonly IMongoCollection<Suggestion> _suggestions;

    public MongoDbSuggestionDao(DbConnection db)
    {
        _suggestions = db.SuggestionCollection;
    }

    public async Task<List<Suggestion>> GetAllSuggestionsAsync()
    {
        var results = await _suggestions.FindAsync(_ => true);
        return await results.ToListAsync();
    }

    public async Task<Suggestion> GetById(string id)
    {
        var results = await _suggestions.FindAsync(u => u.Id == id);
        return await results.FirstOrDefaultAsync();
    }

    public Task Save(Suggestion sugestion)
    {
        return _suggestions.InsertOneAsync(sugestion);
    }

    public Task Update(Suggestion suggestion)
    {
        var filtes = Builders<Suggestion>.Filter.Eq(u => u.Id, suggestion.Id);
        return _suggestions.ReplaceOneAsync(filtes, suggestion, new UpdateOptions { IsUpsert = true });
    }
}