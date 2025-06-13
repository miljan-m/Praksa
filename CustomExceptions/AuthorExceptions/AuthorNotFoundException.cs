namespace LibraryApp.CustomExceptions.AuthorExceptions;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException(int authorId):base($"Author with id = {authorId} doesn't exist") { }

}