namespace SuggestionAppLibrary.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string _id { get; set; }

    private string _objectIdentifier { get; set; }
    private string _firstName { get; set; }
    private string _lastName { get; set; }
    private string _email { get; set; }

    // I dont like this idea of mapping but let's see where it leads
    private List<BasicSuggestion> _authoredSuggestions { get; set; } = new();
    private List<BasicSuggestion> _votedOnSuggestions { get; set; } = new();
}