using LibraryApp.ExtensionClasses;

namespace LibraryApp.Controllers;

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
        var admins = context.getAllAdmins();

        return Ok(admins);
    }

    [HttpGet("{adminid}")]
    public ActionResult<AdminDTO> GetAdmin([FromRoute]int adminid)
    {
        var admin = context.getOneAdminDTO(adminid);
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
    public ActionResult<AdminDTO> CreateAdmin([FromBody] AdminDTO CreateAdminDTO)
    {

        var admin = CreateAdminDTO.mapDtoToAdmin();
        context.Add(admin);
        context.SaveChanges();
        return Ok(CreateAdminDTO);

    }

    [HttpPut("{adminid}")]
    public ActionResult UpdateAdmin([FromRoute]int adminid,[FromBody] AdminDTO updatedAdmin)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();
        admin.UpdateAdminMapping(updatedAdmin);
        context.SaveChanges();
        return Ok();

    }
}