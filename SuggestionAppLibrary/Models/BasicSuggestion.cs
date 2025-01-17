namespace SuggestionAppLibrary.Models;

public class BasicSuggestion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string _id { get; set; }
    
    private string _title { get; set; }
}