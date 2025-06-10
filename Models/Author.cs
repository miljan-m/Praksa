using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;

namespace LibraryApp.Models;

public class Author : IAuthorService
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public List<Book> Books { get; set; }
    private readonly LibraryDBContext context;

    public Author()
    {

    }
    public Author(LibraryDBContext context)
    {
        this.context = context;
    }
    public Author(int AuthorId, string Name, string LastName)
    {
        this.AuthorId = AuthorId;
        this.Name = Name;
        this.LastName = LastName;
    }

    public async Task<IEnumerable<Author>> GetAuthors()
    {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthor(int authorId)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) return null;
        return author;
    }

    public async Task<bool> DeleteAuthor(int authorId)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) return false;
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Author> CreateAuthor(AuthorCreateDTO authorDto)
    {
        var author = authorDto.MapDtoToDomainEntity();
        await context.Authors.AddAsync(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<Author> UpdateAuthor(int authorId, AuthorUpdateDTO updatedAuthor)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) return null;
        author.Name = updatedAuthor.Name;
        author.LastName = updatedAuthor.LastName;
        author.DateOfBirth = updatedAuthor.DateOfBirth;
        await context.SaveChangesAsync();
        return author;
    }
    
}