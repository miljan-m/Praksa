using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    public List<Book> ListOfBooks = new List<Book>
    {
        new("Alisa u zemlji cuda","123456oaihsf","Avantura",true,null),
        new("Lord of rings","asdffrghsf","Avantura",true,null),
        new("Harry Potter","127889asdihsf","Avantura",true,null),
        new("Murder on Nil","deilgoihj2343","Avantura",true,null),
        new("Le Petite Prince","123456oasdaihsf","Avantura",true,null),
        new("The jungle book","189er56oaihsf","Avantura",true,null)


    };

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(ListOfBooks);
    }

    [HttpGet("{Isbn}")]
    public ActionResult<IEnumerable<Book>> GetBook(string Isbn)
    {
        var book = ListOfBooks.FirstOrDefault(e => e.Isbn == Isbn);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> CreateBook(Book book)
    {
        ListOfBooks.Add(book);
        return CreatedAtAction(nameof(GetBook), new { Isbn = book.Isbn }, book);
    }

    [HttpDelete("{Isbn}")]
    public ActionResult<Book> DeleteBook(string Isbn)
    {
        var book = ListOfBooks.FirstOrDefault(book => book.Isbn == Isbn);
        if (book == null) return NotFound();
        ListOfBooks.Remove(book);
        return Ok(book);
    }

    [HttpPut("{Isbn}")]
    public ActionResult<Book> UpdateBook(string Isbn, Book UpdatedBook)
    {
        var book = ListOfBooks.FirstOrDefault(b => b.Isbn == Isbn);
        if (book == null) return NotFound();
        book.Title = UpdatedBook.Title;
        return Ok(book);
    }

}