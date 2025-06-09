using LibraryApp.DTOs;

namespace LibraryApp.Mappers;

public static class ExtensionCustomerMethods
{
    public static CustomerDTO MapDomainEntityToDTO(this Customer customer)
    {
        return new CustomerDTO
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
        };
    }
    public static Customer MapDtoToDomainEntity(this CustomerDTO customerDTO)
    {
        return new Customer
        {
            FirstName = customerDTO.FirstName,
            LastName = customerDTO.LastName,
        };
    }
}