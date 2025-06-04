namespace LibraryApp.Controllers;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{

    private readonly LibraryDBContext context;

    public BookController(LibraryDBContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(context.Books.ToList());
    }

    [HttpGet("{isbn}")]
    public ActionResult<IEnumerable<Book>> GetBook([FromRoute]string Isbn)
    {
        var book = context.Books.Find(Isbn);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody]Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
        return Created(book.Isbn, book);
    }

    [HttpDelete("{isbn}")]
    public ActionResult<Book> DeleteBook([FromRoute]string isbn)
    {
        var book = context.Books.Find(isbn);
        if (book == null) return NotFound();
        context.Books.Remove(book);
        context.SaveChanges();
        return Ok();
    }

    [HttpPut("{isbn}")]
    public ActionResult<Book> UpdateBook([FromRoute]string isbn,[FromBody] Book updatedBook)
    {
        var book = context.Books.Find(isbn);
        if (book == null) return NotFound();
        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        context.SaveChanges();
        return Ok(book);
    }

}