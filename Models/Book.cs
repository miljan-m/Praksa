using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Models.IDomain;
using LibraryApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryApp.Models;

public class Book : IBook
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

     public virtual string BookDetails()
    {
        return $"ISBN: {Isbn}\n Title: {Title}\n Genre: {Genre}\n Available: {Available} \n Special edition:NO";
    }

    public string ShowAutograph()
    {
        return "This is not special edition book. Autograph IS NOT available";
    }
    
}