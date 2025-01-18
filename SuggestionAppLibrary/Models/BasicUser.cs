namespace SuggestionAppLibrary.Models;

public class BasicUser
{
    private string Id;
    private string DisplayName;

    public BasicUser(){}
    public BasicUser(string id, string displayName)
    {
        this.Id = id;
        this.DisplayName = displayName;
    }
}