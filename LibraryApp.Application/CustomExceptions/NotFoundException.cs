namespace LibraryApp.Application.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}