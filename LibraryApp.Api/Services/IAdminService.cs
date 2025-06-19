using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Admin;
using LibraryApp.DTOs.ResponseDTO.Admin;

namespace LibraryApp.Services;

public interface IAdminService
{
    public Task<IEnumerable<GetAdminsDTO>> GetAdmins();
    public Task<GetAdminDTO> GetAdmin(string adminId);
    public Task<bool> DeleteAdmin(string adminId);
    public Task<GetAdminDTO> UpdateAdmin(string adminId, UpdateAdminDTO adminDto);
    public Task<Admin> CreateAdmin(CreateAdminDTO adminDto);
}