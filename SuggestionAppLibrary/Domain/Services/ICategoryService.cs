namespace SuggestionAppLibrary.Domain.Services;

public interface ICategoryService
{
    public Task<List<Category>> GetCategoriesAsync();

    public Task<Category> GetById(string id);
    
    public Task Save(Category category);
}