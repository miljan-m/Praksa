using LibraryApp.CustomExceptions;
using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Author;
using LibraryApp.DTOs.ResponseDTO.Author;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly LibraryDBContext context;

    public AuthorService(LibraryDBContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<GetAuthorsDTO>> GetAuthors()
    {
        var authors = await context.Authors.Select(a => a.MapDomainEntitiesToDto()).ToListAsync();
        if (authors == null) throw new NotFoundException("Database is empty");
        return authors;
    }

    public async Task<Author> GetAuthor(int authorId)
    {
        if (authorId < 0) throw new ArgumentException("Id not valid");
        var author = await context.Authors.Where(a=>a.AuthorId==authorId).FirstOrDefaultAsync();
        if (author == null) throw new NotFoundException("Author can't be found");
        return author;
    }

    public async Task<bool> DeleteAuthor(int authorId)
    {
        if (authorId < 0) throw new ArgumentException("Id not valid");
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) throw new NotFoundException("Author can't be found");
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

    public async Task<GetAuthorDTO> UpdateAuthor(int authorId, AuthorUpdateDTO updatedAuthor)
    {
        if (authorId < 0) throw new ArgumentException("Id not valid");
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) throw new NotFoundException("Author can't be found");
        author.Name = updatedAuthor.Name;
        author.LastName = updatedAuthor.LastName;
        author.DateOfBirth = updatedAuthor.DateOfBirth;
        await context.SaveChangesAsync();
        return author.MapDomainEntityToDto();
    }
}