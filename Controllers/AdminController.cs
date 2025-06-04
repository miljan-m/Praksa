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
    public ActionResult<IEnumerable<Admin>> GetAdmins()
    {
        return Ok(context.Admins.ToList());
    }


    [HttpGet("{adminid}")]
    public ActionResult<Admin> GetAdmin([FromRoute]int adminid)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();
        return Ok(admin);
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
    public ActionResult CreateAdmin([FromBody]Admin admin)
    {
        context.Add(admin);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetAdmin),new { AdminId = admin.AdminId }, admin);
    }

    [HttpPut("{adminid}")]
    public ActionResult UpdateAdmin([FromRoute]int adminid,[FromBody] Admin updatedAdmin)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();
        admin.FirstName = updatedAdmin.FirstName;
        admin.LastName = updatedAdmin.LastName;
        context.SaveChanges();
        return Ok();

    }

}