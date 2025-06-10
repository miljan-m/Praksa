using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryApp.Models;

public class Book
{
    [Key]
    public string Isbn { get; set; }
    public string Title { get; set; }

    public string Genre { get; set; }
    public bool Available { get; set; }
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }

    public Book()
    {
        
    }
    
}