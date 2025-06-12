using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs.RequestDTO.Admin;

public class UpdateAdminDTO
{   
    [Length(1,30, ErrorMessage ="Ime mora biti duzine izmedju 0 i 30 karaktera")]
    public string FirstName { get; set; }
    [Length(1, 30, ErrorMessage = "Prezime mora biti duzine izmedju 0 i 30 karaktera")]
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
}