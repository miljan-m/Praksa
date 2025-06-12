using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs.RequestDTO.Author;

public class AuthorCreateDTO
{   
    [Length(1,30, ErrorMessage ="Ime mora biti duzine izmedju 0 i 30 karaktera")]
    public string Name { get; set; }
    [Length(1,30, ErrorMessage ="Prezime mora biti duzine izmedju 0 i 30 karaktera")]
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
 
}