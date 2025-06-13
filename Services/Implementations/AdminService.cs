using LibraryApp.Constants;
using LibraryApp.CustomExceptions;
using LibraryApp.DTOs.RequestDTO.Admin;
using LibraryApp.DTOs.ResponseDTO.Admin;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;


public class AdminService : IAdminService
{
     private readonly LibraryDBContext context;
    
    public AdminService(LibraryDBContext context)
    {
        this.context = context;
    }
    
    public async Task<IEnumerable<GetAdminsDTO>> GetAdmins()
    {
        var admins=await context.Admins.Select(a => a.MapDomainEntitiesToDTO()).ToListAsync();
        if (admins == null) throw new NotFoundException("Database is empty");
        return admins;
    }

    public async Task<GetAdminDTO> GetAdmin(int adminId)
    {   if (adminId < 0) throw new InvalidArgumentException("Id not valid");
        var admin = await context.Admins.Where(a => a.AdminId == adminId).Select(a => a.MapDomainEntityToDTO()).FirstOrDefaultAsync();
        if (admin == null) throw new NotFoundException("Admin can't be found");
        return admin;
    }

    public async Task<bool> DeleteAdmin(int adminId)
    {   if (adminId < 0) throw new InvalidArgumentException("Id not valid");
        var admin = await context.Admins.FindAsync(adminId);
        if (admin == null) throw new NotFoundException("Admin can't be found");
        context.Admins.Remove(admin);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<GetAdminDTO> UpdateAdmin(int adminId, UpdateAdminDTO adminDto)
    {   if (adminId < 0) throw new InvalidArgumentException("Id not valid");
        var admin = await context.Admins.FindAsync(adminId);
        if (admin == null) throw new NotFoundException("Admin can't be found");
        admin.FirstName = adminDto.FirstName;
        admin.LastName = adminDto.LastName;
        admin.DateOfBirth = adminDto.DateOfBirth;
        await context.SaveChangesAsync();
        return admin.MapDomainEntityToDTO();
    }

    public async Task<Admin> CreateAdmin(CreateAdminDTO adminDto)
    {
        var admin = adminDto.MapDtoToDomainEntity();
        await context.Admins.AddAsync(admin);
        await context.SaveChangesAsync();
        return admin;
    }
}