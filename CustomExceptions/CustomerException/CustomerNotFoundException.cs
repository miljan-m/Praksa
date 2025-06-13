namespace LibraryApp.CustomExceptions.CustomerException;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(int jmbg) : base($"Customer with jmbg = {jmbg} doesn't exist") { }
}