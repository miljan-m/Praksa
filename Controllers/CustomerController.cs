using LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.Services;
using System.Threading.Tasks;
using LibraryApp.DTOs.ResponseDTO.Customer;
using LibraryApp.DTOs.RequestDTO.Customer;

namespace LibraryApp.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    public CustomerController(ICustomerService customerService) {
        this.customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers =await customerService.GetCustomers();
        return Ok(customers);
    }

    [HttpGet("{jmbg}")]
    public async Task<ActionResult<GetCustomerDTO>> GetCustomer([FromRoute]int jmbg)
    {
        var customer =await customerService.GetCustomer(jmbg);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpDelete("{jmbg}")]
    public async Task<ActionResult> DeleteCustomer([FromRoute] int jmbg)
    {
        var isDeleted = await customerService.DeleteCustomer(jmbg);
        if (isDeleted) return NoContent();
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CreateCustomerDTO>> CreateCustomer([FromBody] CreateCustomerDTO customerToCreate)
    {
        var createdCustomer = await customerService.CreateCustomer(customerToCreate);
        var createdCustomerDto = createdCustomer.MapDomainEntityToDTO();
        return CreatedAtAction(nameof(GetCustomer),new{jmbg=createdCustomer.JMBG}, createdCustomerDto);
    }

    [HttpPut("{jmbg}")]
    public async Task<ActionResult<UpdateCustomerDTO>> UpdateCustomer([FromRoute]int jmbg,[FromBody] UpdateCustomerDTO updatedCustomerDTO)
    {
        var customer = await customerService.UpdateCustomer(updatedCustomerDTO, jmbg);
        return Ok(customer);
    }
}