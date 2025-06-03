
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("authors")]
public class AuthorController : ControllerBase
{
    List<Author> ListOfAuthors = new List<Author>
    {
        new(1,"Name1","LastName1"),
        new(2,"Name2","LastName2"),
        new(3,"Name3","LastName3"),
        new(4,"Name4","LastName4"),
        new(5,"Name5","LastName5"),

    };

    [HttpGet]
    public ActionResult<IEnumerable<Author>> GetAuthors()
    {
        return Ok(ListOfAuthors);
    }

    [HttpGet("{AuthorId}")]
    public ActionResult<Author> GetAuthor(int AuthorId)
    {
        var author = ListOfAuthors.FirstOrDefault(a => a.AuthorId == AuthorId);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public ActionResult<Author> CreateAuthor(Author Author)
    {
        ListOfAuthors.Add(Author);
        return CreatedAtAction(nameof(GetAuthor), new { AuthorID = Author.AuthorId }, Author);
    }


    [HttpDelete("{AuthorId}")]
    public ActionResult DeleteAuthor(int id)
    {
        var author = ListOfAuthors.FirstOrDefault(a => a.AuthorId == id);
        if (author == null) return NotFound();
        return NoContent();
    }

    [HttpPut("{AuthorId}")]
    public ActionResult<Author> UpdateAuthor(int Id, Author UpdatedAuthor)
    {
        var author = ListOfAuthors.FirstOrDefault(a => a.AuthorId == Id);
        if (author == null) return NotFound();
        author.Name = UpdatedAuthor.Name;
        author.LastName = UpdatedAuthor.LastName;
        return Ok(author);

    }
}