using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs.RequestDTO.SpecialEditionBook;

public class CreateSpecialBookDTO
{
    [Length(0,50)]
    public string Title { get; set; }
    [AllowedValues("Adventure","Historical","Sci-fi","Action","Crime","Romance")]
    public string Genre { get; set; }
    [AllowedValues("true,false")]
    public bool Available { get; set; }
    [Range(0,50, MinimumIsExclusive =true)]
    public int InStorage { get; set; }
    private string autograph;
    [Length(0,50)]
    public string Autograph { get => autograph; set => autograph = value; }

    
    
}