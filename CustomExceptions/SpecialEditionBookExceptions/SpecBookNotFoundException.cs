namespace LibraryApp.CustomExceptions.BookException;

public class SpecBookNotFoundException : NotFoundException
{
    public SpecBookNotFoundException(string isbn) : base($"Book with isbn = {isbn} doesn't exist") { }
}