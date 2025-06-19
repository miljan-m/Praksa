namespace LibraryApp.Application.DTOs.ResponseDTO.SpecialEditionBook;

public class GetSpecialBooksDTO : GetBookDTO
{
    public int InStorage { get; set; }
    private string autograph;
    public string Autograph { get => autograph; set => autograph = value; }

    public Domen.Models.Author Author { get; set; }
    public int AuthorId { get; set; }
}