using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryApp.Models.BaseDomain;

namespace LibraryApp.Models;

public class Admin : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string AdminId { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime DateCreated { get ; set; }
    public DateTime? DateModified { get ; set;}
    public DateTime? DateDeleted {get ; set; }
    public bool? IsDeleted { get ; set; }

    public Admin()
    {

    }
    public Admin(string AdminId, string FirstName, string LastName)
    {
        this.AdminId = AdminId;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}