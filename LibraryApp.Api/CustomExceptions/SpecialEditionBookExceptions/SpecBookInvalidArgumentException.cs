namespace LibraryApp.CustomExceptions.BookException;

public class SpecBookInvalidArgumentException : InvalidArgumentException
{
    public SpecBookInvalidArgumentException(string isbn) : base($"Given value of id: {isbn} is not valid") { }
}