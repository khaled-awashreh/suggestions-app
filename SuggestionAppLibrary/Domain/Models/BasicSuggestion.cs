namespace SuggestionAppLibrary.Models;

public class BasicSuggestion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string SuggestionText { get; set; }

    public BasicSuggestion() {}

    public BasicSuggestion(Suggestion suggestion)
    {
        this.Id = suggestion.Id;
    }

}