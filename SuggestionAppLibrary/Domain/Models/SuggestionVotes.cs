namespace SuggestionAppLibrary.Models;

public class SuggestionVotes
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string SuggestionId { get; set; }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public HashSet<string> VotingUsers { get; set; } = new HashSet<string>();
}