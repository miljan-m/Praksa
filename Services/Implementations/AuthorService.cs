using LibraryApp.DTOs;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly LibraryDBContext context;

    public AuthorService(LibraryDBContext context)
    {
        this.context = context;
    }
   
    public async Task<IEnumerable<AuthorDTO>> GetAuthors()
    {
        return await context.Authors.Select(a => a.MapDomainEntityToDto()).ToListAsync();
    }

    public async Task<Author> GetAuthor(int authorId)
    {
        var author = await context.Authors.Where(a=>a.AuthorId==authorId).FirstOrDefaultAsync();
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

    public async Task<AuthorDTO> UpdateAuthor(int authorId, AuthorUpdateDTO updatedAuthor)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) return null;
        author.Name = updatedAuthor.Name;
        author.LastName = updatedAuthor.LastName;
        author.DateOfBirth = updatedAuthor.DateOfBirth;
        await context.SaveChangesAsync();
        return author.MapDomainEntityToDto();
    }
}