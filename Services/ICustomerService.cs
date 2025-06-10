using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface ICustomerService
{
    public Task<IEnumerable<Customer>> GetCustomers();
    public Task<Customer> getCustomer(int jmbg);
    public Task<bool> DeleteCustomer(int jmbg);
    public Task<Customer> UpdateCustomer(CustomerDTO updatedCustomer,int jmbg);
    public Task<Customer> CreateCustomer(CustomerDTO customer);
}