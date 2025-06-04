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
    public ActionResult<IEnumerable<Author>> GetAuthors()
    {
        return Ok(context.Authors.ToList());
    }

    [HttpGet("{authorid}")]
    public ActionResult<Author> GetAuthor([FromRoute]int authorid)
    {
        var author = context.Authors.SingleOrDefault(e => e.AuthorId==authorid);        //efficient EF
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public ActionResult<Author> CreateAuthor([FromBody]Author author)
    {
        context.Authors.Add(author);
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
    public ActionResult<Author> UpdateAuthor([FromRoute]int authorid, [FromBody]Author updatedAuthor)
    {
        var author = context.Authors.Find(authorid);
        if (author == null) return NotFound();
        author.Name = updatedAuthor.Name;
        author.LastName = updatedAuthor.LastName;
        context.SaveChanges();
        return Ok(author);

    }
}