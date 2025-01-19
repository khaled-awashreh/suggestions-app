namespace SuggestionAppLibrary.DataAccess;

public interface ISuggestionStatusDao
{
    public Task<List<SuggestionStatus>> GetStatusesAsync();

    public Task<SuggestionStatus> GetById(string id);
    
    public Task Save(SuggestionStatus status);

    public Task Update(SuggestionStatus status);
}