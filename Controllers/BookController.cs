using LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.Services;
using LibraryApp.DTOs.RequestDTO.Book;

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
    public async Task<ActionResult<IEnumerable<GetBooksDTO>>> GetBooks()
    {
        var books = await bookService.GetBooks();
        return Ok(books);
    }

    [HttpGet("{isbn}")]
    public async Task<ActionResult<GetBookDTO>> GetBook([FromRoute] string isbn)
    {
        var book =await bookService.GetBook(isbn);
        return Ok(book);
    }

    [HttpPost("{authorId}")]
    public async Task<ActionResult<GetBookDTO>> CreateBook([FromBody] BookCreateDTO bookCreateDTO, [FromRoute] int authorId)
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
    public async Task<ActionResult<GetBookDTO>> UpdateBook([FromRoute] string isbn, [FromBody] BookUpdateDTO updatedBook)
    {
        var book =await bookService.UpdateBook(isbn,updatedBook);
        if (book == null) return NotFound();
        return Ok(book);
    }

}