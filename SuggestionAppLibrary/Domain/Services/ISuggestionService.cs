namespace SuggestionAppLibrary.Domain.Services;

public interface ISuggestionService
{
    public Task<List<Suggestion>> GetAllSuggestionsAsync();

    public Task<Suggestion> GetById(string id);
    
    public Task Save(Suggestion sugestion);

    
    public Task UpvoteASuggestion(string id, string userId);
}