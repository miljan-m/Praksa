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
    [EndpointSummary("Gets all existing authors")]
    [EndpointDescription("This endpoint returns all authors")]
    public async Task<ActionResult<IEnumerable<GetAuthorsDTO>>> GetAuthors()
    {
        var authors = await authorService.GetAuthors();
        return Ok(authors);
    }

    [HttpGet("{authorId}")]
    [EndpointSummary("Gets one author")]
    [EndpointDescription("This endpoint returns one author based on provided id")]
    public async Task<ActionResult<GetAuthorDTO>> GetAuthor([FromRoute] string authorId)
    {
        var author = await authorService.GetAuthor(authorId);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    [EndpointSummary("Creation of new author")]
    [EndpointDescription("This endpoint creates new author based on information that has been provided in body of request")]
    public async Task<ActionResult<GetAuthorDTO>> CreateAuthor([FromBody] AuthorCreateDTO authorCreate)
    {
        var author = await authorService.CreateAuthor(authorCreate);
        return Ok(author);
    }

    [HttpDelete("{authorId}")]
    [EndpointSummary("Removing author")]
    [EndpointDescription("This endpoint deletes author based on provided id")]
    public async Task<ActionResult> DeleteAuthor([FromRoute] string authorId)
    {
        var isDeleted = await authorService.DeleteAuthor(authorId);
        if (isDeleted == false) return NotFound();
        return NoContent();
    }

    [HttpPut("{authorId}")]
    [EndpointSummary("Updating author")]
    [EndpointDescription("This endpoint updates author based on information that has been provided in body of request")]
    public async Task<ActionResult<GetAuthorDTO>> UpdateAuthor([FromRoute] string authorId, [FromBody] AuthorUpdateDTO updatedAuthor)
    {
        var author = await authorService.UpdateAuthor(authorId, updatedAuthor);
        if (author == null) return NotFound();
        return Ok(author);
    }
}