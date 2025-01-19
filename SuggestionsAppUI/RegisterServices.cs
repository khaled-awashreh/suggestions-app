using SuggestionAppLibrary.DataAccess;

namespace SuggestionsAppUI;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMemoryCache();
    }

    public static void ConfigureDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDbConnection, DbConnection>();
        builder.Services.AddSingleton<ICategoryDao, MongoDbCategoryDao>();
        builder.Services.AddSingleton<IUserDao, MongoDbUserDao>();
        builder.Services.AddSingleton<ISuggestionDao, MongoDbSuggestionDao>();
        builder.Services.AddSingleton<ISuggestionStatusDao, MongoDbSuggestionStatusDao>();
        builder.Services.AddSingleton<ISuggestionVotesDao, MongoDbSuggestionVotesDao>();
    }


}