using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess;

public interface IDbConnection
{
    string DbName { get; }
    string CategoryCollectionName { get; }
    string StatusCollectionName { get; }
    string UserCollectionName { get; }
    string SuggestionCollectionName { get; }

    MongoClient Client { get; }
    IMongoCollection<Category> CategoryCollection { get; }
    IMongoCollection<Suggestion> SuggestionCollection { get; }
    IMongoCollection<User> UserCollection { get; }
    IMongoCollection<SuggestionStatus> StatusCollection { get; }
}
