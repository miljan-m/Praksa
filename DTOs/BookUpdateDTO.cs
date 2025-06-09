using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs;
public class BookUpdateDTO
{
    [Key]
    public string Title { get; set; }

    public string Genre { get; set; }

    public bool Available { get; set; }
    
}