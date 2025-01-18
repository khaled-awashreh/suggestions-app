namespace SuggestionAppLibrary.DataAccess;

public class MongoDbCategoryDao: ICategoryDao
{
    public Task<List<Category>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task Save(Category category)
    {
        throw new NotImplementedException();
    }

    public Task Update(Category category)
    {
        throw new NotImplementedException();
    }
}