using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface IAdminService
{
    public Task<IEnumerable<AdminDTO>> GetAdmins();
    public Task<AdminDTO> GetAdmin(int adminId);
    public Task<bool> DeleteAdmin(int adminId);
    public Task<AdminDTO> UpdateAdmin(int adminId, AdminDTO adminDto);
    public Task<Admin> CreateAdmin(AdminDTO adminDto);
}