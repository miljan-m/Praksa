using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Admin : IAdminService
{
    public int AdminId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    private readonly LibraryDBContext context;
    public Admin()
    {
        
    }
    public Admin(LibraryDBContext context)
    {
        this.context = context;
    }
    public Admin(int AdminId, string FirstName, string LastName)
    {
        this.AdminId = AdminId;
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    public async Task<IEnumerable<Admin>> GetAdmins()
    {
        return await context.Admins.ToListAsync();
    }

    public async Task<Admin> GetAdmin(int adminId)
    {
        return await context.Admins.FindAsync(adminId);
    }

    public async Task<bool> DeleteAdmin(int adminId)
    {
        var admin = await context.Admins.FindAsync(adminId);
        if (admin == null) return false;
        context.Admins.Remove(admin);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Admin> UpdateAdmin(int adminId, AdminDTO adminDto)
    {
        var admin = await context.Admins.FindAsync(adminId);
        if (admin == null) return null;
        admin.FirstName = adminDto.FirstName;
        admin.LastName = adminDto.LastName;
        admin.DateOfBirth = adminDto.DateOfBirth;
        await context.SaveChangesAsync();
        return admin;
    }

    public async Task<Admin> CreateAdmin(AdminDTO adminDto)
    {
        var admin = adminDto.MapDtoToDomainEntity();
        await context.Admins.AddAsync(admin);
        await context.SaveChangesAsync();
        return admin;
    }
}