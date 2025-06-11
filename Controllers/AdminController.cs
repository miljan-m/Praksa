using LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.Services;
using System.Threading.Tasks;
using LibraryApp.DTOs.ResponseDTO.Admin;
using LibraryApp.DTOs.RequestDTO.Admin;

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
    public async Task<ActionResult<IEnumerable<GetAdminsDTO>>> GetAdmins()
    {
        var adminsDto = await adminService.GetAdmins();
        return Ok(adminsDto);
    }

    [HttpGet("{adminId}")]
    public async Task<ActionResult<GetAdminDTO>> GetAdmin([FromRoute] int adminId)
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
    public async Task<ActionResult<GetAdminDTO>> CreateAdmin([FromBody] CreateAdminDTO createAdminDto)
    {
        var admin = await adminService.CreateAdmin(createAdminDto);
        return CreatedAtAction(nameof(CreateAdmin), new { adminId = admin.AdminId }, admin.MapDomainEntityToDTO());
    }

    [HttpPut("{adminId}")]
    public async Task<ActionResult<GetAdminDTO>> UpdateAdmin([FromRoute] int adminId, [FromBody] UpdateAdminDTO updatedAdmin)
    {
        var admin = await adminService.UpdateAdmin(adminId, updatedAdmin);
        if (admin == null) return NotFound();
        return Ok(admin);

    }
}