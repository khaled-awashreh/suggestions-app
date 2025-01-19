using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoDbCategoryDao : ICategoryDao
{
    private IMongoCollection<Category> _categories;
    private IMemoryCache _cache;
    private const string _cacheKey = "categoriesData";

    public MongoDbCategoryDao(IMongoCollection<Category> categories, IMemoryCache cache)
    {
        _categories = categories;
        _cache = cache;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var output = _cache.Get<List<Category>>(_cacheKey);
        if (output == null)
        {
            var results = await _categories.FindAsync(_ => true);
            output = results.ToList();
            _cache.Set(_cacheKey, output, TimeSpan.FromDays(1));
        }

        return output;
    }

    public async Task<Category> GetById(string id)
    {
        var results = await _categories.FindAsync(category => category.Id == id);
        return results.FirstOrDefault();
    }

    public Task Save(Category category)
    {
        return _categories.InsertOneAsync(category);
    }

    public Task Update(Category category)
    {
        var filter = Builders<Category>.Filter.Eq(c => c.Id, category.Id);
        return _categories.ReplaceOneAsync(filter, category, new ReplaceOptions { IsUpsert = true });
    }
}