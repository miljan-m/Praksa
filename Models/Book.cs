using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models;

public class Book
{
    public  string Title { get; set; }
    
    [Key]
    public string Isbn { get; set; }
    public  string Genre { get; set; }
    public bool Available { get; set; }
    public Author? Author { get; set; }
    
    public Book()
    {
        
    }
    
 /* public Book(string Title, string Isbn, string Genre, bool Available)
                {
                    this.Title = Title;
                    this.Isbn = Isbn;
                    this.Genre = Genre;
                    this.Available = Available;
                }*/

    public Book(string Title, string Isbn, string Genre, bool Available, Author? Author)
    {
        this.Title = Title;
        this.Isbn = Isbn;
        this.Genre = Genre;
        this.Available = Available;
        this.Author = Author;
    }
}