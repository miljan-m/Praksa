namespace LibraryApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryApp.Data;

[ApiController]
[Route("admins")]
public class AdminController : ControllerBase
{

    private readonly LibraryDBContext context;
    public AdminController(LibraryDBContext context)
    {
        this.context = context;
    }


    [HttpGet]
    public ActionResult<IEnumerable<AdminDTO>> GetAdmins()
    {
        var admins = from a in context.Admins
                     select new AdminDTO
                     {
                         FirstName = a.FirstName,
                         LastName = a.LastName,
                         DateOfBirth = a.DateOfBirth
                     };

        return Ok(admins);
    }


    [HttpGet("{adminid}")]
    public ActionResult<AdminDTO> GetAdmin([FromRoute]int adminid)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();
        var adminForExit = new AdminDTO
        {
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            DateOfBirth=admin.DateOfBirth
        };
        return Ok(adminForExit);
    }


    [HttpDelete("{adminid}")]
    public ActionResult DeleteAdmin([FromRoute]int adminid)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();
        context.Remove(admin);
        context.SaveChanges();
        return Ok();

    }


    [HttpPost]
    public ActionResult<AdminDTO> CreateAdmin([FromBody] AdminDTO CreateAdminDTO)
    {

        var admin = new Admin
        {
            FirstName = CreateAdminDTO.FirstName,
            LastName = CreateAdminDTO.LastName,
            DateOfBirth = CreateAdminDTO.DateOfBirth
        };

        context.Add(admin);
        context.SaveChanges();
        return Ok(CreateAdminDTO);

    }

    [HttpPut("{adminid}")]
    public ActionResult UpdateAdmin([FromRoute]int adminid,[FromBody] AdminDTO updatedAdmin)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();
        admin.FirstName = updatedAdmin.FirstName;
        admin.LastName = updatedAdmin.LastName;
        admin.DateOfBirth = updatedAdmin.DateOfBirth;
        context.SaveChanges();
        return Ok();

    }

}