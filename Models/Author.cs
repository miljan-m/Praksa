using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Author 
{
    [Key]
    public string AuthorId { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public List<Book> Books { get; set; }
    
    public Author()
    {

    }

     public Author(string AuthorId, string Name, string LastName)
    {
        this.AuthorId = AuthorId;
        this.Name = Name;
        this.LastName = LastName;
    }
}