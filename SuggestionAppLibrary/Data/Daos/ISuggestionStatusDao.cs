namespace SuggestionAppLibrary.DataAccess;

public interface ISuggestionStatusDao
{
    public Task<List<SuggestionStatus>> GetAllStatusesAsync();

    public Task<SuggestionStatus> GetById(string id);
    
    public Task Save(SuggestionStatus status);

}