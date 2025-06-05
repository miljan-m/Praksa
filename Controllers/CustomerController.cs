namespace LibraryApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryApp.Data;

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
        var customers = context.Customers.Select(c => new CustomerDTO
        {
            FirstName = c.FirstName,
            LastName = c.LastName
        });

        return Ok(customers);
    }

    [HttpGet("{jmbg}")]
    public ActionResult<Customer> GetCustomer([FromRoute]int jmbg)
    {
        //var customer = context.Customers.ToList().FirstOrDefault(c => c.JMBG == jmbg);
        var customer = context.Customers.Where(c => c.JMBG == jmbg).Select(c => new CustomerDTO
        {
            FirstName = c.FirstName,
            LastName=c.LastName
        }).FirstOrDefault();
        if (customer == null) return NotFound();
        return Ok(customer);
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
        var customer = new Customer
        {
            FirstName = customerToCreate.FirstName,
            LastName = customerToCreate.LastName
        };
        context.Customers.Add(customer);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetCustomer), new { JMBG = customer.JMBG }, customerToCreate);
    }

    [HttpPut("{jmbg}")]
    public ActionResult<Customer> UpdateCustomer([FromRoute]int jmbg,[FromBody] CustomerDTO updatedCustomerDTO)
    {
        var customer = context.Customers.Find(jmbg);
        if (customer == null) return NotFound();
        customer.FirstName = updatedCustomerDTO.FirstName;
        customer.LastName = updatedCustomerDTO.LastName;
        context.SaveChanges();
        return Ok(updatedCustomerDTO);

    }

}