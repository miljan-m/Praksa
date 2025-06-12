namespace LibraryApp.DTOs.RequestDTO.SpecialEditionBook;

public class UpdateSpecialBookDTO
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public bool Available { get; set; }
    public int InStorage { get; set; }
    private string autograph;
    public string Autograph { get => autograph; set => autograph = value; }
    
}