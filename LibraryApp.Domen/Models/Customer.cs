using System.ComponentModel.DataAnnotations;
using LibraryApp.Domen.Abstractions;

namespace LibraryApp.Domen.Models;


public class Customer : IBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Key]
    public string JMBG { get; set; }

    public Customer()
    {

    }
    public Customer(string FirstName, string LastName, string JMBG)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.JMBG = JMBG;
    }
}