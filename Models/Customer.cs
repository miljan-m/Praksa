using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Customer :ICustomerService
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Key]
    public int JMBG { get; set; }

    private readonly LibraryDBContext contex;

    public Customer()
    {

    }

    public Customer(LibraryDBContext context)
    {
        this.contex = context;
    }

    public Customer(string FirstName, string LastName, int JMBG)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.JMBG = JMBG;
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await contex.Customers.ToListAsync();
    }

    public async Task<Customer> getCustomer(int jmbg)
    {
        return await contex.Customers.FindAsync(jmbg);
    }

    public async Task<bool> DeleteCustomer(int jmbg)
    {
        var customer = await contex.Customers.FindAsync(jmbg);
        if (customer == null) return false;
        contex.Remove(customer);
        await contex.SaveChangesAsync();
        return true;
    }

    public async Task<Customer> UpdateCustomer(CustomerDTO updatedCustomer, int jmbg)
    {
        var customer = await contex.Customers.FindAsync(jmbg);
        if (customer == null) return null;
        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        await contex.SaveChangesAsync();
        return customer;   
    }

    public async Task<Customer> CreateCustomer(CustomerDTO customer)
    {
        var nonDtoCustomer = customer.MapDtoToDomainEntity();
        await contex.Customers.AddAsync(nonDtoCustomer);
        await contex.SaveChangesAsync();
        return nonDtoCustomer;
    }
}