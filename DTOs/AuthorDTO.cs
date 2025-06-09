namespace LibraryApp.DTOs;

public class AuthorDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public List<Book> Books{ get; set; }

    
}