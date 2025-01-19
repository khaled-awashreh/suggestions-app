namespace SuggestionAppLibrary.Domain.Services;

public interface ISuggestionStatusService
{
    public Task<List<SuggestionStatus>> GetAllStatusesAsync();

    public Task<SuggestionStatus> GetById(string id);
    
    public Task Save(SuggestionStatus status);
}