namespace LibraryApp.Controllers;

using System.Data.Common;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<IEnumerable<BookDTO>> GetBooks()
    {
        var books = from b in context.Books
                    select new BookDTO()
                    {
                        Isbn = b.Isbn,
                        Title = b.Title,
                        Genre = b.Genre,
                        Available = b.Available,
                        AuthorName = b.Author == null ? "NEMA AUTORA" : b.Author.Name
                    };
        return Ok(books);
    }

    [HttpGet("{isbn}")]
    public ActionResult<IEnumerable<Book>> GetBook([FromRoute] string isbn)
    {

          var book = context.Books
              .Where(b => b.Isbn == isbn)
              .Select(b => new BookDTO
                  {
                      Isbn = b.Isbn,
                      Title = b.Title,
                      Genre = b.Genre,
                      Available = b.Available,
                      AuthorName = b.Author == null ? "NEMA AUTORA" : b.Author.Name
                  }
                  ).FirstOrDefault();
        
        
        return Ok(book);
    }

    [HttpPost("{authorid}")]
    public ActionResult<BookDTO> CreateBook([FromBody] BookCreateDTO bookCreateDTO, [FromRoute] int authorid)
    {

        var author = context.Authors.Find(authorid);
        if (author == null) return NotFound();
        var book = new Book
        {
            Isbn = bookCreateDTO.Isbn,
            Title = bookCreateDTO.Title,
            Genre = bookCreateDTO.Genre,
            Available = bookCreateDTO.Available,
            AuthorId = authorid,
            Author = author
        };

        context.Books.Add(book);
        context.SaveChanges();

        context.Entry(book).Reference(a => a.Author).Load();

        var bookForExit = new BookDTO
        {
            Isbn = book.Isbn,
            Title = book.Title,
            Genre = book.Genre,
            Available = book.Available,

        };

        return CreatedAtAction(nameof(GetBook), new { isbn = book.Isbn }, bookForExit);
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
    public ActionResult<BookDTO> UpdateBook([FromRoute]string isbn,[FromBody] BookUpdateDTO updatedBook)
    {
        var book = context.Books.Include(b => b.Author).FirstOrDefault(b => b.Isbn == isbn);
        if (book.Author == null) return NotFound();
        if (book == null) return NotFound();
        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        context.SaveChanges();
        
         var bookForExit = new BookDTO
        {
            Isbn = book.Isbn,
            Title = book.Title,
            Genre = book.Genre,
            Available = book.Available,
            AuthorName=book.Author.Name,
        };
        return Ok(bookForExit);
    }

}