
namespace LibraryApp.ExtensionClasses;

public static class AdminMethods
{

    public static IEnumerable<AdminDTO> getAllAdmins(this LibraryDBContext context)
    {
        var admins = from a in context.Admins
                     select new AdminDTO
                     {
                         FirstName = a.FirstName,
                         LastName = a.LastName,
                         DateOfBirth = a.DateOfBirth
                     };

        return admins;
    }

    public static ActionResult<AdminDTO> getOneAdminDTO(this LibraryDBContext context, int adminId)
    {
        var admin = context.Admins.Find(adminId);
        var adminDTO = new AdminDTO
        {
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            DateOfBirth = admin.DateOfBirth
        };
        return adminDTO;
    }

    public static Admin mapDtoToAdmin(this AdminDTO adminDTO)
    {
        var admin = new Admin
        {
            FirstName = adminDTO.FirstName,
            LastName = adminDTO.LastName,
            DateOfBirth = adminDTO.DateOfBirth
        };
        return admin;
    }

    public static Admin UpdateAdminMapping(this Admin admin, AdminDTO updatedAdmin)
    {
        admin.FirstName = updatedAdmin.FirstName;
        admin.LastName = updatedAdmin.LastName;
        admin.DateOfBirth = updatedAdmin.DateOfBirth;
        return admin;
    }
}