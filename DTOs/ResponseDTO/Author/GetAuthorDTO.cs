namespace LibraryApp.DTOs.ResponseDTO.Author;

public class GetAuthorDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public List<Book> Books{ get; set; }

    
}