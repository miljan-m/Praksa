using LibraryApp.Mappers;

namespace LibraryApp.Controllers;

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
        var books = context.Books.Select(b => b.MapDomainEntityToDTO());
        return Ok(books);
    }

    [HttpGet("{isbn}")]
    public ActionResult<BookDTO> GetBook([FromRoute] string isbn)
    {
        var book = context.Books
                    .Where(b => b.Isbn == isbn)
                    .Select(b => b.MapDomainEntityToDTO());
        return Ok(book);
    }

    [HttpPost("{authorId}")]
    public ActionResult<BookDTO> CreateBook([FromBody] BookCreateDTO bookCreateDTO, [FromRoute] int authorId)
    {
        var author = context.Authors.Find(authorId);
        if (author == null) return NotFound();
        var book = bookCreateDTO.MapDtoToDomainEntity(author);

        context.Books.Add(book);
        context.SaveChanges();

        var toRetBook = book.MapDomainEntityToDTO();
        return CreatedAtAction(nameof(GetBook), new { isbn = book.Isbn }, toRetBook);
    }

    [HttpDelete("{isbn}")]
    public ActionResult<Book> DeleteBook([FromRoute] string isbn)
    {
        var book = context.Books.Find(isbn);
        if (book == null) return NotFound();
        context.Books.Remove(book);
        context.SaveChanges();
        return Ok();
    }

    [HttpPut("{isbn}")]
    public ActionResult<BookDTO> UpdateBook([FromRoute] string isbn, [FromBody] BookUpdateDTO updatedBook)
    {
        var book = context.Books
                    .Include(a => a.Author)
                    .FirstOrDefault(b => b.Isbn == isbn);
        if (book == null) return NotFound();
        if (book.Author == null) return NotFound();

        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        context.SaveChanges();

        var bookForExit = book.MapDomainEntityToDTO();
        return Ok(bookForExit);
    }

}