using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Customer 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Key]
    public int JMBG { get; set; }

    public Customer()
    {

    }
    public Customer(string FirstName, string LastName, int JMBG)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.JMBG = JMBG;
    }
}