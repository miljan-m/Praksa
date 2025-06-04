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
        return Ok(context.Customers.ToList());
    }

    [HttpGet("{jmbg}")]
    public ActionResult<Customer> GetCustomer([FromRoute]int jmbg)
    {
        var customer = context.Customers.ToList().FirstOrDefault(c => c.JMBG == jmbg);
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
    public ActionResult<Customer> CreateCustomer([FromBody]Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetCustomer), new { JMBG = customer.JMBG }, customer);
    }

    [HttpPut("{jmbg}")]
    public ActionResult<Customer> UpdateCustomer([FromRoute]int jmbg,[FromBody] Customer updatedCustomer)
    {
        var customer = context.Customers.Find(jmbg);
        if (customer == null) return NotFound();
        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        context.SaveChanges();
        return Ok(customer);

    }

}