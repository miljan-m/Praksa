using LibraryApp.Mappers;

namespace LibraryApp.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly LibraryDBContext context;

    public CustomerController(LibraryDBContext context) {
        this.context = context;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = context.Customers.Select(c => c.MapDomainEntityToDTO());
        return Ok(customers);
    }

    [HttpGet("{jmbg}")]
    public ActionResult<CustomerDTO> GetCustomer([FromRoute]int jmbg)
    {
        var customer = context.Customers.Find(jmbg);
        var customerDto=customer.MapDomainEntityToDTO();
        if (customer == null) return NotFound();
        return Ok(customerDto);
    }

    [HttpDelete("{jmbg}")]
    public ActionResult DeleteCustomer([FromRoute]int jmbg)
    {
        var customer = context.Customers.Find(jmbg);
        if (customer == null) return NotFound();
        context.Remove(customer);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPost]
    public ActionResult<CustomerDTO> CreateCustomer([FromBody]CustomerDTO customerToCreate)
    {
        var customer = customerToCreate.MapDtoToDomainEntity();
        context.Customers.Add(customer);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetCustomer), new { JMBG = customer.JMBG }, customerToCreate);
    }

    [HttpPut("{jmbg}")]
    public ActionResult<CustomerDTO> UpdateCustomer([FromRoute]int jmbg,[FromBody] CustomerDTO updatedCustomerDTO)
    {
        var customer = context.Customers.Find(jmbg);
        if (customer == null) return NotFound();

        customer.FirstName = updatedCustomerDTO.FirstName;
        customer.LastName = updatedCustomerDTO.LastName;

        context.SaveChanges();
        return Ok(customer.MapDomainEntityToDTO());

    }
}