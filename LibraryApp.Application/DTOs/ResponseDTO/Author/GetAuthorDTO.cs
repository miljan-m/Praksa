namespace LibraryApp.Application.DTOs.ResponseDTO.Author;

public class GetAuthorDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public List<Domen.Models.Book> Books{ get; set; }

    
}