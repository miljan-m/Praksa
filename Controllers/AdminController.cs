using LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.Services;
using System.Threading.Tasks;

namespace LibraryApp.Controllers;

[ApiController]
[Route("admins")]
public class AdminController : ControllerBase
{

    private readonly IAdminService adminService;

    public AdminController(IAdminService adminService)
    {
        this.adminService = adminService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAdmins()
    {
        var adminsDto = await adminService.GetAdmins();
        return Ok(adminsDto);
    }

    [HttpGet("{adminId}")]
    public async Task<ActionResult<AdminDTO>> GetAdmin([FromRoute] int adminId)
    {
        var adminDto = await adminService.GetAdmin(adminId);
        return Ok(adminDto);
    }

    [HttpDelete("{adminId}")]
    public async Task<ActionResult> DeleteAdmin([FromRoute]int adminId)
    {
        var isDeleted =await adminService.DeleteAdmin(adminId);
        if (isDeleted) return Ok();
        return NotFound();

    }

    [HttpPost]
    public async Task<ActionResult<AdminDTO>> CreateAdmin([FromBody] AdminDTO createAdminDto)
    {
        var admin = await adminService.CreateAdmin(createAdminDto);
        var adminDto = admin.MapDomainEntityToDTO();
        return CreatedAtAction(nameof(CreateAdmin), new { adminId = admin.AdminId }, adminDto);
    }

    [HttpPut("{adminId}")]
    public async Task<ActionResult<AdminDTO>> UpdateAdmin([FromRoute] int adminId, [FromBody] AdminDTO updatedAdmin)
    {
        var admin = await adminService.UpdateAdmin(adminId, updatedAdmin);
        if (admin == null) return NotFound();
        return Ok(admin);

    }
}