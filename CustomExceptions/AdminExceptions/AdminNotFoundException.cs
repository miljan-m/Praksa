namespace LibraryApp.CustomExceptions.AdminException;

public class AdminNotFoundException : NotFoundException
{
    public AdminNotFoundException(int adminId) : base($"Author with id = {adminId} doesn't exist") { }
}