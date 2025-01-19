using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess;

public class DbConnection :IDbConnection
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase _database;
    private string _connectionId = "MongoDB";
    
    public string DbName { get; private set; }

    public string CategoryCollectionName  { get; private set; } = "categories";
    public string StatusCollectionName  { get; private set; } = "statuses";
    public string UserCollectionName  { get; private set; } = "users";
    public string SuggestionCollectionName  { get; private set; } = "suggestions";
    public string SuggestionVoteCollectionName { get; }

    public MongoClient Client { get; private set; }
    public IMongoCollection<Category> CategoryCollection { get; private set; }
    public IMongoCollection<Suggestion> SuggestionCollection { get; private set; }
    public IMongoCollection<User> UserCollection { get; private set; }
    public IMongoCollection<SuggestionVotes> SuggestionVoteCollection { get; }
    public IMongoCollection<SuggestionStatus> StatusCollection { get; private set; }
    public DbConnection(IConfiguration configuration)
    {
        _configuration = configuration;
        Client = new MongoClient(_configuration.GetConnectionString(_connectionId));
        DbName = _configuration["DatabaseName"];
        _database = Client.GetDatabase(DbName);
        
        CategoryCollection = _database.GetCollection<Category>(CategoryCollectionName);
        SuggestionCollection = _database.GetCollection<Suggestion>(SuggestionCollectionName);
        UserCollection = _database.GetCollection<User>(UserCollectionName);
        StatusCollection = _database.GetCollection<SuggestionStatus>(StatusCollectionName);
        SuggestionVoteCollection = _database.GetCollection<SuggestionVotes>(SuggestionVoteCollectionName);
    }
}