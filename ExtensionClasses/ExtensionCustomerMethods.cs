
namespace LibraryApp.ExtensionClasses;

public static class ExtensionCustomerMethods
{

    public static IQueryable<CustomerDTO> GetAllCustomers(this LibraryDBContext context)
    {
        var customers = context.Customers.Select(c => new CustomerDTO
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
        });

        return customers;
    }

    public static CustomerDTO GetOneCustomer(this LibraryDBContext context, int jmbg)
    {
        var customer = context.Customers.Where(c => c.JMBG == jmbg).Select(c => new CustomerDTO
        {
            FirstName = c.FirstName,
            LastName = c.LastName
        }).FirstOrDefault();

        return customer;
    }

    public static Customer MapDtoToCustomer(this CustomerDTO customerDTO)
    {
        var customer = new Customer
        {
            FirstName = customerDTO.FirstName,
            LastName = customerDTO.LastName,
        };
        return customer;
    }

    public static Customer UpdateCustomerMapping(this Customer customer, CustomerDTO updatedCustomer)
    {
        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        return customer;
    }

}