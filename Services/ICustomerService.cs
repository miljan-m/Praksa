using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Customer;
using LibraryApp.DTOs.ResponseDTO.Customer;

namespace LibraryApp.Services;

public interface ICustomerService
{
    public Task<IEnumerable<GetCustomersDTO>> GetCustomers();
    public Task<GetCustomerDTO> GetCustomer(int jmbg);
    public Task<bool> DeleteCustomer(int jmbg);
    public Task<UpdateCustomerDTO> UpdateCustomer(UpdateCustomerDTO updatedCustomer,int jmbg);
    public Task<Customer> CreateCustomer(CreateCustomerDTO customer);
}