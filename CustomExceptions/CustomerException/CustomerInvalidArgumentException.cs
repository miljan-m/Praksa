namespace LibraryApp.CustomExceptions.CustomerException;

public class CustomerInvalidArgumentException : InvalidArgumentException
{
    public CustomerInvalidArgumentException(int jmbg) : base($"Given value of id: {jmbg} is not valid") { }
}