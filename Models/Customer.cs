using System.ComponentModel.DataAnnotations;
using LibraryApp.Models.BaseDomain;

namespace LibraryApp.Models;

public class Customer : IBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Key]
    public string JMBG { get; set; }

    public DateTime DateCreated { get ; set; }
    public DateTime? DateModified { get ; set; }
    public DateTime? DateDeleted { get ; set; }
    public bool? IsDeleted { get ; set; }

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