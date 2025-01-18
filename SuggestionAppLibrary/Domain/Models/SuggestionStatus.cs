namespace SuggestionAppLibrary.Models;

public class SuggestionStatus
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string _id {  get; set; }
    private string _name { get; set; }
    private string _description { get; set; }
}