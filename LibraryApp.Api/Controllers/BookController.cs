using LibraryApp.Application.Interfaces;
using LibraryApp.Application.DTOs.ResponseDTO.Books;
using LibraryApp.Application.DTOs.RequestDTO.Book;

namespace LibraryApp.Api.Controllers;

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
    [EndpointSummary("Get all existing books")]
    [EndpointDescription("This endpoint returns list of all books. Informations about isbn and book's author are excluded")]
    public async Task<ActionResult<IEnumerable<GetBooksDTO>>> GetBooks()
    {
        var books = await bookService.GetBooks();
        return Ok(books);
    }


    [HttpGet("{isbn}")]
    [EndpointSummary("Get one book")]
    [EndpointDescription("This endpoint returns one book based on provided isbn. Informations about isbn and book's author are excluded")]
    public async Task<ActionResult<GetBookDTO>> GetBook([FromRoute] string isbn)
    {
        var book = await bookService.GetBook(isbn);
        return Ok(book);
    }

    [HttpPost("{authorId}")]
    [EndpointSummary("Creation of new book")]
    [EndpointDescription("This endpoint creates new book based on information that has been provided in body of request")]
    public async Task<ActionResult<GetBookDTO>> CreateBook([FromBody] BookCreateDTO bookCreateDTO, [FromRoute] string authorId)
    {
        var toRetBook = await bookService.CreateBook(bookCreateDTO, authorId);
        return Ok(toRetBook);
    }

    [HttpDelete("{isbn}")]
    [EndpointSummary("Removing book")]
    [EndpointDescription("This endpoint deletes book based on provided isbn")]
    public async Task<IActionResult> DeleteBook([FromRoute] string isbn)
    {
        var book = await bookService.DeleteBook(isbn);
        if (book == false) return NotFound();
        return NoContent();
    }

    [HttpPut("{isbn}")]
    [EndpointSummary("Updating book")]
    [EndpointDescription("This endpoint updates book based on provided isbn")]
    public async Task<ActionResult<GetBookDTO>> UpdateBook([FromRoute] string isbn, [FromBody] BookUpdateDTO updatedBook)
    {
        var book = await bookService.UpdateBook(isbn, updatedBook);
        if (book == null) return NotFound();
        return Ok(book);
    }

}