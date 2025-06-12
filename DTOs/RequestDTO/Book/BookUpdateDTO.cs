using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs.RequestDTO.Book;

public class BookUpdateDTO
{

    [Length(0,25, ErrorMessage ="Naziv knjige mora imati izmedju 0 i 30 karaktera")]
    public string Title { get; set; }
    [AllowedValues("Adventure","Historical","Sci-fi","Action","Crime","Romance")]
    public string Genre { get; set; }
    [AllowedValues("true","false")]
    public bool Available { get; set; }

}