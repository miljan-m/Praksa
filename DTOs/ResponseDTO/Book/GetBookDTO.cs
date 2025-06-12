using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs;

public class GetBookDTO
{
    [Key]
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public bool Available { get; set; }
    public string AuthorName{ get; set; }
    
}