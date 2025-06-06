using LibraryApp.Mappers;

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
        var admins = context.Admins.Select(a => a.MapDomainEntityToDTO());
        return Ok(admins);
    }

    [HttpGet("{adminId}")]
    public ActionResult<AdminDTO> GetAdmin([FromRoute]int adminId)
    {
        var admin = context.Admins.Find(adminId);
        admin.MapDomainEntityToDTO();
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
    public ActionResult<AdminDTO> CreateAdmin([FromBody] AdminDTO CreateAdminDto)
    {

        var admin = CreateAdminDto.MapDtoToDomainEntity();
        context.Add(admin);
        context.SaveChanges();
        return Ok(CreateAdminDto);

    }

    [HttpPut("{adminid}")]
    public ActionResult<AdminDTO> UpdateAdmin([FromRoute]int adminid,[FromBody] AdminDTO updatedAdmin)
    {
        var admin = context.Admins.Find(adminid);
        if (admin == null) return NotFound();

        admin.FirstName = updatedAdmin.FirstName;
        admin.LastName = updatedAdmin.LastName;
        admin.DateOfBirth = updatedAdmin.DateOfBirth;
       
        context.SaveChanges();

        return Ok(admin.MapDomainEntityToDTO());

    }
}