using LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.Services;

namespace LibraryApp.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IBookService bookService;
    public BookController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
    {
        var books = await bookService.GetBooks();
        var allBooks = books.Select(b => b.MapDomainEntityToDTO());
        return Ok(allBooks);
    }

    [HttpGet("{isbn}")]
    public async Task<ActionResult<Book>> GetBook([FromRoute] string isbn)
    {
        var book =await bookService.GetBook(isbn);
        var bookDto = book.MapDomainEntityToDTO();
        return Ok(bookDto);
    }

    [HttpPost("{authorId}")]
    public async Task<ActionResult<BookDTO>> CreateBook([FromBody] BookCreateDTO bookCreateDTO, [FromRoute] int authorId)
    {
        var toRetBook =await bookService.CreateBook( bookCreateDTO, authorId);
        return CreatedAtAction(nameof(GetBook), new { isbn = toRetBook.Isbn }, toRetBook);
    }

    [HttpDelete("{isbn}")]
    public async Task<IActionResult> DeleteBook([FromRoute] string isbn)
    {
        var book = await bookService.DeleteBook( isbn);
        if (book == false) return NotFound();
        return NoContent();
    }

    [HttpPut("{isbn}")]
    public async Task<ActionResult<BookDTO>> UpdateBook([FromRoute] string isbn, [FromBody] BookUpdateDTO updatedBook)
    {
        var book =await bookService.UpdateBook(isbn,updatedBook);
        var bookForExit = book.MapDomainEntityToDTO();
        return Ok(bookForExit);
    }

}