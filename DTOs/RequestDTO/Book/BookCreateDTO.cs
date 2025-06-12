using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs.RequestDTO.Book;


public class BookCreateDTO
{
    [Key]
    public string Isbn { get; set; }
    public string Title { get; set; }

    public string Genre { get; set; }
    public bool Available { get; set; }
    
}