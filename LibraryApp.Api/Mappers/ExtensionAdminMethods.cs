
namespace LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Admin;
using LibraryApp.DTOs.ResponseDTO.Admin;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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

    public static Admin MapDtoToDomainEntity(this UpdateAdminDTO adminDto,Admin admin)
    {
        admin.FirstName = adminDto.FirstName;
        admin.LastName = adminDto.LastName;
        admin.DateOfBirth = adminDto.DateOfBirth;
        return admin;
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
            DateOfBirth = admin.DateOfBirth
        };
    }
    


    

}