using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Admin
{
    public int AdminId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Admin()
    {

    }
    public Admin(int AdminId, string FirstName, string LastName)
    {
        this.AdminId = AdminId;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}