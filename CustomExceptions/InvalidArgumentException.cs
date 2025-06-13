namespace LibraryApp.CustomExceptions;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException(string message) : base(message) { }
}