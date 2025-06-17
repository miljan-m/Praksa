using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Admin
{
    [Key]
    public string AdminId { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Admin()
    {

    }
    public Admin(string AdminId, string FirstName, string LastName)
    {
        this.AdminId = AdminId;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}