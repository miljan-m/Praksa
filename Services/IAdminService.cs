using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Admin;
using LibraryApp.DTOs.ResponseDTO.Admin;

namespace LibraryApp.Services;

public interface IAdminService
{
    public Task<IEnumerable<GetAdminsDTO>> GetAdmins();
    public Task<GetAdminDTO> GetAdmin(int adminId);
    public Task<bool> DeleteAdmin(int adminId);
    public Task<GetAdminDTO> UpdateAdmin(int adminId, UpdateAdminDTO adminDto);
    public Task<Admin> CreateAdmin(CreateAdminDTO adminDto);
}