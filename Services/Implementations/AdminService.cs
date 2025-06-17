using LibraryApp.CustomExceptions;
using LibraryApp.CustomExceptions.AdminException;
using LibraryApp.Data.DbRepository;
using LibraryApp.DTOs.RequestDTO.Admin;
using LibraryApp.DTOs.ResponseDTO.Admin;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;


public class AdminService : IAdminService
{
    private readonly IGenericRepository<Admin> adminRepository;
    public AdminService(IGenericRepository<Admin> adminRepository)
    {
        this.adminRepository = adminRepository;
    }
    
    public async Task<IEnumerable<GetAdminsDTO>> GetAdmins()
    {
        var adminsList =await adminRepository.GetAllAsync();
        var admins = adminsList.Select(a => a.MapDomainEntitiesToDTO()).ToList();
        if (admins == null) throw new NotFoundException("Database is empty");
        return admins;
    }

    public async Task<GetAdminDTO> GetAdmin(string adminId)
    {
        //if (int.Parse(adminId) < 0) throw new AdminInvalidArgumentException(adminId);
        var admin = await adminRepository.GetOneAsync(adminId);
        if (admin == null) throw new AdminNotFoundException(adminId);
        var adminDto = admin.MapDomainEntityToDTO();
        return adminDto;
    }

    public async Task<bool> DeleteAdmin(string adminId)
    {
        //if (int.Parse(adminId) < 0) throw new AdminInvalidArgumentException(adminId);
        return await adminRepository.DeleteAsync(adminId); 
    }

    public async Task<GetAdminDTO> UpdateAdmin(string adminId, UpdateAdminDTO adminDto)
    {
        //if (int.Parse(adminId) < 0) throw new AdminInvalidArgumentException(adminId);
        var admin = await adminRepository.GetOneAsync(adminId);
        if (admin == null) throw new AdminNotFoundException(adminId);
        var updatedAdmin = await adminRepository.UpdateAsync(adminDto.MapDtoToDomainEntity(adminId), adminId);
        return updatedAdmin.MapDomainEntityToDTO();
    }

    public async Task<Admin> CreateAdmin(CreateAdminDTO adminDto)
    {
        var admin = adminDto.MapDtoToDomainEntity();
        return  await adminRepository.CreateAsync(admin);
    }
}