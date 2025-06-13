namespace LibraryApp.CustomExceptions.AdminException;

public class AdminInvalidArgumentException : InvalidArgumentException
{
    public AdminInvalidArgumentException(int adminId) : base($"Given value of admin id: {adminId} is not valid") { }
}