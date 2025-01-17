namespace SuggestionAppLibrary.Models;

public class Suggestion
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string _id { get; set; }
    
    private string _suggesiton { get; set; }
    private string _description { get; set; }
    private string _author { get; set; }
    private string _notes { get; set; }    
    
    private DateTime _createdOn { get; set; } = DateTime.Now;
    private HashSet<string> _votedUsers { get; set; } = new();

    private Category _category { get; set; }
    private SuggestionStatus _status { get; set; }

    private bool _approvedForRelease { get; set; } = false;
    private bool _archived { get; set; } = false;
    private bool _rejected { get; set; } = false;

}