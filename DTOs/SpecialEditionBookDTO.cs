namespace LibraryApp.DTOs;

public class SpecialEditionBookDTO : GetBookDTO
{
    public int InStorage { get; set; }
    private string autograph;
    public string Autograph { get => autograph; set => autograph = value; }

    public Author Author { get; set; }
    public int AuthorId{ get; set; }
}