using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs.RequestDTO.Customer;

public class UpdateCustomerDTO
{
    [Length(1,30, ErrorMessage ="Ime mora biti duzine izmedju 0 i 30 karaktera")]
    public string FirstName { get; set; }
    [Length(1,30, ErrorMessage ="Ime mora biti duzine izmedju 0 i 30 karaktera")]
    public string LastName { get; set; }
   
}