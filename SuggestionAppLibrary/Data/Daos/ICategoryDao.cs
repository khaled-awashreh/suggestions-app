namespace SuggestionAppLibrary.DataAccess;

public interface ICategoryDao
{
    public Task<List<Category>> GetCategoriesAsync();

    public Task<Category> GetById(string id);
    
    public Task Save(Category category);

}