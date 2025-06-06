using LibraryApp.ExtensionClasses;

namespace LibraryApp.Controllers;

[ApiController]
[Route("authors")]
public class AuthorController : ControllerBase
{
    private readonly LibraryDBContext context;
    public AuthorController(LibraryDBContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AuthorDTO>> GetAuthors()
    {
        var authors = context.GetAllAuthors();
        return Ok(authors);
    }

    [HttpGet("{authorid}")]
    public ActionResult<AuthorDTO> GetAuthor([FromRoute]int authorid)
    {
        var author = context.GetOneAuthor(authorid);
        if (author == null) return NotFound();
        context.Entry(author).Collection(a => a.Books).Load();
        var authorForExit = ExtensionAuthorMethods.MapAuthorToDTO(author);
        return Ok(authorForExit);
    }

    [HttpPost]
    public ActionResult<AuthorDTO> CreateAuthor([FromBody] AuthorCreateDTO authorCreate)
    {
        Author author=null;
        author = author.MapDtoToAuthor(authorCreate);
        context.Add(author);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetAuthor), new { AuthorID = author.AuthorId }, author); 
    }

    [HttpDelete("{authorid}")]
    public ActionResult DeleteAuthor([FromRoute]int authorid)
    {
        var author = context.Authors.Find(authorid);
        if (author == null) return NotFound();
        context.Authors.Remove(author);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{authorid}")]
    public ActionResult<Author> UpdateAuthor([FromRoute]int authorid, [FromBody]AuthorUpdateDTO updatedAuthor)
    {
        var author = context.Authors.Find(authorid);
        if (author == null) return NotFound();
        author.UpdateAuthor(updatedAuthor);
        context.SaveChanges();
        var authorForExit = author.MapAuthorToDTO();
        return Ok(authorForExit);

    }
}