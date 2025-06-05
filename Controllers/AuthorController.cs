namespace LibraryApp.Controllers;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

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
        var authors = from a in context.Authors
                      select new AuthorDTO
                      {
                          Name = a.Name,
                          LastName = a.LastName,
                          DateOfBirth = a.DateOfBirth,
                          Books = a.Books
                      };

        return Ok(authors);
    }

    [HttpGet("{authorid}")]
    public ActionResult<AuthorDTO> GetAuthor([FromRoute]int authorid)
    {
        var author = context.Authors.SingleOrDefault(e => e.AuthorId==authorid);        //efficient EF
        context.Entry(author).Collection(a => a.Books).Load();
        var authorForExit = new AuthorDTO
        {
            Name = author.Name,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
            
        };
        if (author == null) return NotFound();
        return Ok(authorForExit);
    }

    [HttpPost]
    public ActionResult<AuthorDTO> CreateAuthor([FromBody] AuthorCreateDTO authorCreate)
    {

        var author = new Author
        {
            Name = authorCreate.Name,
            LastName = authorCreate.LastName,
            DateOfBirth = authorCreate.DateOfBirth
        };

        context.Add(author);
        context.SaveChanges();

        var authorForExit = new AuthorDTO
        {
            Name = author.Name,
            LastName = author.LastName,
            DateOfBirth=author.DateOfBirth
        };
       
        return CreatedAtAction(nameof(GetAuthor), new { AuthorID = author.AuthorId }, authorForExit); 
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
    public ActionResult<Author> UpdateAuthor([FromRoute]int authorid, [FromBody]AuthorDTO updatedAuthor)
    {
        var author = context.Authors.Find(authorid);
        if (author == null) return NotFound();
        author.Name = updatedAuthor.Name;
        author.LastName = updatedAuthor.LastName;
        context.SaveChanges();
        return Ok(author);

    }
}