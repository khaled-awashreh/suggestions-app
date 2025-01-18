namespace SuggestionAppLibrary.Models;

public class Suggestion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string SuggestionText { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }

    public string Notes { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public HashSet<string> VotedUsers { get; set; } = new HashSet<string>();

    public Category Category { get; set; }

    public SuggestionStatus Status { get; set; }

    public bool ApprovedForRelease { get; set; } = false;

    public bool Archived { get; set; } = false;

    public bool Rejected { get; set; } = false;
}