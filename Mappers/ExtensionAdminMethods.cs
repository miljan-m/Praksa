
namespace LibraryApp.Mappers;
using LibraryApp.DTOs;

public static class AdminMethods
{

    public static Admin MapDtoToDomainEntity(this AdminDTO adminDTO)
    {
        return new Admin
        {
            FirstName = adminDTO.FirstName,
            LastName = adminDTO.LastName,
            DateOfBirth = adminDTO.DateOfBirth
        };
    }

    public static AdminDTO MapDomainEntityToDTO(this Admin admin)
    {
        return new AdminDTO
        {
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            DateOfBirth=admin.DateOfBirth
        };
    }
}