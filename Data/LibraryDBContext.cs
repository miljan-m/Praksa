using System.Data;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data;

public class LibraryDBContext : DbContext
{
    public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
    {

    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Book> Books{ get; set; }
    public DbSet<Customer> Customers{ get; set; }
    public DbSet<Rent> Rents{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var Author1 = new Author(1, "Author1Name", "Author1LastName");
        var Author2 = new Author(2, "Author2Name", "Author2LastName");
        var Author3 = new Author(3, "Author3Name", "Author3LastName");
        var Author4 = new Author(4, "Author4Name", "Author4LastName");

        var Admin1 = new Admin(1, "Admin1Name", "Admin1LastName");
        var Admin2 = new Admin(2, "Admin2Name", "Admin2LastName");
        var Admin3 = new Admin(3, "Admin3Name", "Admin3LastName");
        var Admin4 = new Admin(4, "Admin4Name", "Admin4LastName");
        var Admin5 = new Admin(5, "Admin5Name", "Admin5LastName");

        var Book1 = new Book("Alisa u zemlji cuda", "123456oaihsf", "Avantura", true, null);
        var Book2 = new Book("Lord of rings", "asdffrghsf", "Avantura", true, null);
        var Book3 = new Book("Harry Potter", "127889asdihsf", "Avantura", true, null);
        var Book4 = new Book("Murder on Nil", "deilgoihj2343", "Avantura", true, null);
        var Book5 = new Book("Le Petite Prince", "123456oadadadasf", "Avantura", true, null);
        var Book6 = new Book("The jungle book", "189er56oaihsf", "Avantura", true, null);

        var Customer1 = new Customer("Customer1Name", "Customer1LastName",123456);
        var Customer2 = new Customer("Customer2Name", "Customer2LastName",239184762);
        var Customer3 = new Customer("Customer3Name", "Customer3LastName",329456);
        var Customer4 = new Customer("Customer4Name", "Customer4LastName",324857);
        var Customer5 = new Customer("Customer5Name", "Customer5LastName",238476);


        modelBuilder.Entity<Author>().HasData(Author1, Author2, Author3, Author4);
        modelBuilder.Entity<Admin>().HasData(Admin1, Admin2, Admin3, Admin4, Admin5);
        modelBuilder.Entity<Book>().HasData(Book1, Book2, Book3, Book4, Book5, Book6);
        modelBuilder.Entity<Customer>().HasData(Customer1, Customer2, Customer3, Customer4, Customer5);

    }

}