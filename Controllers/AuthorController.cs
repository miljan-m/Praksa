using LibraryApp.Mappers;
using LibraryApp.DTOs;
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
        var authors = context.Authors.Select(a => a.MapDomainEntityToDto());
        return Ok(authors);
    }

    [HttpGet("{authorId}")]
    public ActionResult<AuthorDTO> GetAuthor([FromRoute]int authorId)
    {
        var authorDto = context.Authors
                    .Include(a => a.Books)
                    .Where(a => a.AuthorId == authorId).Select(a => a.MapDomainEntityToDto())
                    .FirstOrDefault();
                    
        return Ok(authorDto);
    }

    [HttpPost]
    public ActionResult<AuthorDTO> CreateAuthor([FromBody] AuthorCreateDTO authorCreate)
    {
        var author = authorCreate.MapDtoToDomainEntity();
        context.Add(author);
        context.SaveChanges();
        var authorDto = author.MapDomainEntityToDto();
        return CreatedAtAction(nameof(GetAuthor), new { AuthorID = author.AuthorId }, authorDto); 
    }

    [HttpDelete("{authorId}")]
    public ActionResult DeleteAuthor([FromRoute]int authorId)
    {
        var author = context.Authors.Find(authorId);
        if (author == null) return NotFound();
        context.Authors.Remove(author);
        context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{authorId}")]
    public ActionResult<Author> UpdateAuthor([FromRoute]int authorId, [FromBody]AuthorUpdateDTO updatedAuthor)
    {
        var author = context.Authors.Find(authorId);
        if (author == null) return NotFound();
        
        author.Name = updatedAuthor.Name;
        author.LastName = updatedAuthor.LastName;
        author.DateOfBirth = updatedAuthor.DateOfBirth;
        context.SaveChanges();

        var toRetAuthor = author.MapDomainEntityToDto();
        return Ok(toRetAuthor);
    }
}