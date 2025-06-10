using LibraryApp.Mappers;
using LibraryApp.DTOs;
using LibraryApp.Services;
using System.Threading.Tasks;

namespace LibraryApp.Controllers;

[ApiController]



[Route("authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService authorService;
    public AuthorController(IAuthorService authorService)
    {
        this.authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
    {
        var authors = await authorService.GetAuthors();
        return Ok(authors.Select(a => a.MapDomainEntityToDto()));
    }

    [HttpGet("{authorId}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthor([FromRoute] int authorId)
    {
        var author = await authorService.GetAuthor(authorId);
        if (author == null) return NotFound();
        return Ok(author.MapDomainEntityToDto());
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDTO>> CreateAuthor([FromBody] AuthorCreateDTO authorCreate)
    {
        var author = await authorService.CreateAuthor(authorCreate);
        return CreatedAtAction(nameof(GetAuthor),new {authorId=author.AuthorId } ,author.MapDomainEntityToDto());
    }

    [HttpDelete("{authorId}")]
    public async Task<ActionResult> DeleteAuthor([FromRoute] int authorId)
    {
        var isDeleted = await authorService.DeleteAuthor(authorId);
        if (isDeleted == false) return NotFound();
        return NoContent();
    }

    [HttpPut("{authorId}")]
    public async Task<ActionResult<Author>> UpdateAuthor([FromRoute] int authorId, [FromBody] AuthorUpdateDTO updatedAuthor)
    {
        var author = await authorService.UpdateAuthor(authorId, updatedAuthor);
        if (author == null) return NotFound();
        return Ok(author.MapDomainEntityToDto());
    }
}