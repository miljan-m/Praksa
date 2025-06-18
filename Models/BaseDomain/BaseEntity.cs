namespace LibraryApp.Models.BaseDomain;

public interface IBaseEntity
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { get; set; }
    public bool? IsDeleted { get; set; }
}