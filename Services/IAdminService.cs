using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface IAdminService
{
    public Task<IEnumerable<Admin>> GetAdmins();
    public Task<Admin> GetAdmin(int adminId);
    public Task<bool> DeleteAdmin(int adminId);
    public Task<Admin> UpdateAdmin(int adminId, AdminDTO adminDto);
    public Task<Admin> CreateAdmin(AdminDTO adminDto);
}