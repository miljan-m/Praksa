namespace LibraryApp.DTOs.RequestDTO.Admin;

public class CreateAdminDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
}