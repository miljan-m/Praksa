namespace LibraryApp.CustomExceptions.AuthorExceptions;

public class AuthorInvalidArgumentException : InvalidArgumentException
{
    public AuthorInvalidArgumentException(int authorId):base($"Given value of id: {authorId} is not valid") { }

}