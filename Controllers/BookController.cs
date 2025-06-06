using LibraryApp.ExtensionClasses;

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
        var books = context.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("{isbn}")]
    public ActionResult<IEnumerable<BookDTO>> GetBook([FromRoute] string isbn)
    {
        var book = context.GetOneBook(isbn);
        return Ok(book);
    }

    [HttpPost("{authorid}")]
    public ActionResult<BookDTO> CreateBook([FromBody] BookCreateDTO bookCreateDTO, [FromRoute] int authorid)
    {
        var author = context.Authors.Find(authorid);
        if (author == null) return NotFound();
        var book = ExtensionBookMethods.MapDtoToBook(bookCreateDTO, author);

        context.Books.Add(book);
        context.SaveChanges();

        context.Entry(book).Reference(a => a.Author).Load();

        var bookForExit = author.MapAuthorToDTO();

        return CreatedAtAction(nameof(GetBook), new { isbn = book.Isbn }, bookForExit);
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
        var book = context.GetFullBook(isbn);
        if (book.Author == null) return NotFound();
        if (book == null) return NotFound();
        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        context.SaveChanges();

        var bookForExit = book.MapBookToBookDTO();
        return Ok(bookForExit);
    }

}