using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{

    List<Customer> ListOfCustomers = new List<Customer>
    {
        new("Name1","LastName1",123456),
        new("Name2","LastName2",987654),
        new("Name3","LastName3",9687645),
        new("Name4","LastName4",123778),
        new("Name5","LastName5",798621),

    };


    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return Ok(ListOfCustomers);
    }

    [HttpGet("{JMBG}")]
    public ActionResult<Customer> GetCustomer(int JMBG)
    {
        var customer = ListOfCustomers.FirstOrDefault(c => c.JMBG == JMBG);
        if (customer == null) return NotFound();
        return Ok(customer);



    }

    [HttpDelete("{JMBG}")]
    public ActionResult DeleteCustomer(int JMBG)
    {
        var customer = ListOfCustomers.FirstOrDefault(c => c.JMBG == JMBG);
        if (customer == null) return NotFound();
        ListOfCustomers.Remove(customer);
        return NoContent();

    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer Customer)
    {
        ListOfCustomers.Add(Customer);
        return CreatedAtAction(nameof(GetCustomer), new { JMBG = Customer.JMBG }, Customer);
    }

    [HttpPut("{JMBG}")]
    public ActionResult<Customer> UpdateCustomer(int JMBG, Customer UpdatedCustomer)
    {
        var customer = ListOfCustomers.FirstOrDefault(c => c.JMBG == JMBG);
        if (customer == null) return NotFound();
        customer.FirstName = UpdatedCustomer.FirstName;
        customer.LastName = UpdatedCustomer.LastName;
        return Ok(customer);
    }

}