using LibraryApp.Mappers;
using LibraryApp.DTOs.RequestDTO.Author;
using LibraryApp.Services;
using LibraryApp.DTOs.ResponseDTO.Author;

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
    public async Task<ActionResult<IEnumerable<GetAuthorsDTO>>> GetAuthors()
    {
        var authors = await authorService.GetAuthors();
        return Ok(authors);
    }

    [HttpGet("{authorId}")]
    public async Task<ActionResult<GetAuthorDTO>> GetAuthor([FromRoute] int authorId)
    {
        var author = await authorService.GetAuthor(authorId);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<GetAuthorDTO>> CreateAuthor([FromBody] AuthorCreateDTO authorCreate)
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
    public async Task<ActionResult<GetAuthorDTO>> UpdateAuthor([FromRoute] int authorId, [FromBody] AuthorUpdateDTO updatedAuthor)
    {
        var author = await authorService.UpdateAuthor(authorId, updatedAuthor);
        if (author == null) return NotFound();
        return Ok(author);
    }
}