using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface ICustomerService
{
    public Task<IEnumerable<CustomerDTO>> GetCustomers();
    public Task<CustomerDTO> GetCustomer(int jmbg);
    public Task<bool> DeleteCustomer(int jmbg);
    public Task<CustomerDTO> UpdateCustomer(CustomerDTO updatedCustomer,int jmbg);
    public Task<Customer> CreateCustomer(CustomerDTO customer);
}