using LibraryApp.DTOs;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly LibraryDBContext contex;


    public CustomerService(LibraryDBContext context)
    {
        this.contex = context;
    }

    

    public async Task<IEnumerable<CustomerDTO>> GetCustomers()
    {
        return await contex.Customers.Select(c=>c.MapDomainEntityToDTO()).ToListAsync();
    }

    public async Task<CustomerDTO> GetCustomer(int jmbg)
    {
        return await contex.Customers.Where(c=>c.JMBG==jmbg).Select(c=>c.MapDomainEntityToDTO()).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteCustomer(int jmbg)
    {
        var customer = await contex.Customers.FindAsync(jmbg);
        if (customer == null) return false;
        contex.Remove(customer);
        await contex.SaveChangesAsync();
        return true;
    }

    public async Task<CustomerDTO> UpdateCustomer(CustomerDTO updatedCustomer, int jmbg)
    {
        var customer = await contex.Customers.FindAsync(jmbg);
        if (customer == null) return null;
        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        await contex.SaveChangesAsync();
        return customer.MapDomainEntityToDTO();   
    }

    public async Task<Customer> CreateCustomer(CustomerDTO customer)
    {
        var nonDtoCustomer = customer.MapDtoToDomainEntity();
        await contex.Customers.AddAsync(nonDtoCustomer);
        await contex.SaveChangesAsync();
        return nonDtoCustomer;
    }
}