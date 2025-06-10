using LibraryApp.DTOs;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;


public class AdminService : IAdminService
{
     private readonly LibraryDBContext context;
    
    public AdminService(LibraryDBContext context)
    {
        this.context = context;
    }
    
    public async Task<IEnumerable<AdminDTO>> GetAdmins()
    {
        return await context.Admins.Select(a => a.MapDomainEntityToDTO()).ToListAsync();
    }

    public async Task<AdminDTO> GetAdmin(int adminId)
    {
        return await context.Admins.Where(a => a.AdminId == adminId).Select(a => a.MapDomainEntityToDTO()).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteAdmin(int adminId)
    {
        var admin = await context.Admins.FindAsync(adminId);
        if (admin == null) return false;
        context.Admins.Remove(admin);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<AdminDTO> UpdateAdmin(int adminId, AdminDTO adminDto)
    {
        var admin = await context.Admins.FindAsync(adminId);
        if (admin == null) return null;
        admin.FirstName = adminDto.FirstName;
        admin.LastName = adminDto.LastName;
        admin.DateOfBirth = adminDto.DateOfBirth;
        await context.SaveChangesAsync();
        return admin.MapDomainEntityToDTO();
    }

    public async Task<Admin> CreateAdmin(AdminDTO adminDto)
    {
        var admin = adminDto.MapDtoToDomainEntity();
        await context.Admins.AddAsync(admin);
        await context.SaveChangesAsync();
        return admin;
    }
}