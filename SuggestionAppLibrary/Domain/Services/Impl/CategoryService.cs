namespace SuggestionAppLibrary.Domain.Services.Impl;

public class CategoryService : ICategoryService
{
    private readonly ICategoryDao _categoryDao;
    public Task<List<Category>> GetCategoriesAsync()
    {
        return _categoryDao.GetCategoriesAsync();
    }

    public Task<Category> GetById(string id)
    {
        return _categoryDao.GetById(id);
    }

    public Task Save(Category category)
    {
        return _categoryDao.Save(category);
    }
}