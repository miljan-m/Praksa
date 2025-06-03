namespace LibraryApp.Models;

public class Author
{
    public int AuthorId{ get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public Author(int AuthorId,string Name, string LastName)
    {
        this.AuthorId = AuthorId;
        this.Name = Name;
        this.LastName = LastName;
    }
}