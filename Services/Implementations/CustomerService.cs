using LibraryApp.CustomExceptions;
using LibraryApp.CustomExceptions.CustomerException;
using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Customer;
using LibraryApp.DTOs.ResponseDTO.Customer;
using LibraryApp.Mappers;
using Microsoft.VisualBasic;

namespace LibraryApp.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly LibraryDBContext contex;


    public CustomerService(LibraryDBContext context)
    {
        this.contex = context;
    }

    public async Task<IEnumerable<GetCustomersDTO>> GetCustomers()
    {
        var customers = await contex.Customers.Select(c => c.MapDomainEntitiesToDTO()).ToListAsync();
        if (customers == null) throw new NotFoundException("Database is empty");
        return customers;
    }

    public async Task<GetCustomerDTO> GetCustomer(int jmbg)
    {   
        if (jmbg < 0 ||  jmbg.ToString().Length > 13) throw new CustomerInvalidArgumentException(jmbg);
        var customer = await contex.Customers.Where(c => c.JMBG == jmbg).Select(c => c.MapDomainEntityToDTO()).FirstOrDefaultAsync();
        if (customer == null) throw new CustomerNotFoundException(jmbg);
        return customer;
    }

    public async Task<bool> DeleteCustomer(int jmbg)
    {   
        if (jmbg < 0 || jmbg.ToString().Length > 13) throw new CustomerInvalidArgumentException(jmbg);
        var customer = await contex.Customers.FindAsync(jmbg);
        if (customer == null) throw new CustomerNotFoundException(jmbg);
        contex.Remove(customer);
        await contex.SaveChangesAsync();
        return true;
    }

    public async Task<UpdateCustomerDTO> UpdateCustomer(UpdateCustomerDTO updatedCustomer, int jmbg)
    {
        if (jmbg < 0 || jmbg.ToString().Length > 13) throw new CustomerInvalidArgumentException(jmbg);
        var customer = await contex.Customers.FindAsync(jmbg);
        if (customer == null) throw new CustomerNotFoundException(jmbg);
        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        await contex.SaveChangesAsync();
        return updatedCustomer;   
    }

    public async Task<Customer> CreateCustomer(CreateCustomerDTO customer)
    {
        var nonDtoCustomer = customer.MapDtoToDomainEntity();
        await contex.Customers.AddAsync(nonDtoCustomer);
        await contex.SaveChangesAsync();
        return nonDtoCustomer;
    }
}