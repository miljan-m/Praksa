
namespace LibraryApp.DTOs.ResponseDTO.SpecialEditionBook;

public class GetSpecialBookDTO : GetBooksDTO
{
    public int InStorage { get; set; }
    private string autograph;
    public string Autograph { get => autograph; set => autograph = value; }

    public Models.Author Author { get; set; }
    public int AuthorId { get; set; }
}