using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;

[ApiController]
[Route("admins")]
public class AdminController : ControllerBase
{

    List<Admin> ListOfAdmins = new List<Admin>
    {
        new(1,"AdminName1","AdminLastName1"),
        new(2,"AdminName2","AdminLastName2"),
        new(3,"AdminName3","AdminLastName3"),
        new(4,"AdminName4","AdminLastName4"),
        new(5,"AdminName5","AdminLastName5"),

    };

    [HttpGet]
    public ActionResult<IEnumerable<Admin>> GetAdmins()
    {
        return Ok(ListOfAdmins);
    }


    [HttpGet("{AdminId}")]
    public ActionResult<Admin> GetAdmin(int AdminId)
    {
        var admin = ListOfAdmins.FirstOrDefault(a => a.AdminId == AdminId);
        if (admin == null) return NotFound();
        return Ok(admin);
    }


    [HttpDelete("{AdminId}")]
    public ActionResult DeleteAdmin(int AdminId)
    {
        var admin = ListOfAdmins.FirstOrDefault(a => a.AdminId == AdminId);
        if (admin == null) return NotFound();
        ListOfAdmins.Remove(admin);
        return NoContent();

    }


    [HttpPost]
    public ActionResult CreateAdmin(Admin Admin)
    {
        ListOfAdmins.Add(Admin);
        return CreatedAtAction(nameof(GetAdmin), new { AdminId = Admin.AdminId }, Admin);
    }

    [HttpPut("{AdminId}")]
    public ActionResult UpdateAdmin(int AdminId, Admin UpdatedAdmin)
    {
        var admin = ListOfAdmins.FirstOrDefault(a => a.AdminId == AdminId);
        if (admin == null) return NotFound();
        admin.FirstName = UpdatedAdmin.FirstName;
        admin.LastName = UpdatedAdmin.LastName;
        admin.DateOfBirth = UpdatedAdmin.DateOfBirth;
        return Ok();

    }

}