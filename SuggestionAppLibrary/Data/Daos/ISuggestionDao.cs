namespace SuggestionAppLibrary.DataAccess;

public interface ISuggestionDao
{
    public Task<List<Suggestion>> GetAllSuggestionsAsync();

    public Task<Suggestion> GetById(string id);
    
    public Task Save(Suggestion sugestion);

    public Task Update(Suggestion suggestion);
}