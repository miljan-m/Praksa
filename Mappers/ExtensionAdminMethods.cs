
namespace LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Admin;
using LibraryApp.DTOs.ResponseDTO.Admin;

public static class AdminMethods
{

    public static Admin MapDtoToDomainEntity(this CreateAdminDTO adminDTO)
    {
        return new Admin
        {
            FirstName = adminDTO.FirstName,
            LastName = adminDTO.LastName,
            DateOfBirth = adminDTO.DateOfBirth
        };
    }

     public static Admin MapDtoToDomainEntity(this UpdateAdminDTO adminDTO)
    {
        return new Admin
        {
            FirstName = adminDTO.FirstName,
            LastName = adminDTO.LastName,
            DateOfBirth = adminDTO.DateOfBirth
        };
    }

    public static GetAdminDTO MapDomainEntityToDTO(this Admin admin)
    {
        return new GetAdminDTO
        {
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            DateOfBirth = admin.DateOfBirth
        };
    }
    
       public static GetAdminsDTO MapDomainEntitiesToDTO(this Admin admin)
    {
        return new GetAdminsDTO
        {
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            DateOfBirth=admin.DateOfBirth
        };
    }
}