using LibraryApp.DTOs;
using LibraryApp.Services;

namespace LibraryApp.Controllers;

[ApiController]
[Route("/specialbook")]
public class SpecialEditionBookController : ControllerBase
{
    private readonly ISpecialEditionBookService bookService;

    public SpecialEditionBookController(ISpecialEditionBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SpecialEditionBookDTO>>> GetSpecialBooks()
    {
        var specialBooks = await bookService.GetBooks();
        return Ok(specialBooks);
    }

    [HttpGet("{isbn}")]
    public async Task<ActionResult<SpecialEditionBookDTO>> GetSpecialBook([FromRoute] string isbn)
    {
        var book = await bookService.GetBook(isbn);
        return Ok(book);
    }

    [HttpDelete("{isbn}")]
    public async Task<ActionResult> DeleteSpecialBook(string isbn)
    {
        var isDeleted = await bookService.DeleteBook(isbn);
        if (isDeleted == false) return NotFound();
        return Ok();
    }

    [HttpPost("{authorId}")]
    public async Task<ActionResult<SpecialEditionBookDTO>> CreateSpecialBook([FromRoute] int authorId, SpecialEditionBookCreateDTO specialEditionBook)
    {
        var book = await bookService.CreateBook(specialEditionBook, authorId);

        return Ok(book);
    }

    [HttpPut("{isbn}")]
    public async Task<ActionResult<SpecialEditionBookDTO>> UpdateSpecialBook([FromRoute] string isbn, [FromBody] SpecialEditionBookCreateDTO updatedBook)
    {
        var specialBookDto = await bookService.UpdateBook(isbn, updatedBook);
        if (specialBookDto == null) return NotFound();
        return Ok(specialBookDto);
    }

}