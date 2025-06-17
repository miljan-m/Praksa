using LibraryApp.CustomExceptions;
using LibraryApp.CustomExceptions.AuthorExceptions;
using LibraryApp.Data.DbRepository;
using LibraryApp.DTOs.RequestDTO.Author;
using LibraryApp.DTOs.ResponseDTO.Author;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly IGenericRepository<Author> authorRepository;

    public AuthorService(IGenericRepository<Author> authorRepository)
    {
        this.authorRepository = authorRepository;
    }

    public async Task<IEnumerable<GetAuthorsDTO>> GetAuthors()
    {
        var authors = await authorRepository.GetAllAsync();
        var authorsDto = authors.Select(a => a.MapDomainEntitiesToDto());
        if (authors == null) throw new NotFoundException("Database is empty");
        return authorsDto;
    }

    public async Task<Author> GetAuthor(string authorId)
    {
        //if (int.Parse(authorId) < 0) throw new AuthorInvalidArgumentException(authorId);
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        return author;
    }

    public async Task<bool> DeleteAuthor(string authorId)
    {
        //if (int.Parse(authorId) < 0) throw new AuthorInvalidArgumentException(authorId);
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        return await authorRepository.DeleteAsync(authorId);
    }

    public async Task<Author> CreateAuthor(AuthorCreateDTO authorDto)
    {
        var author = authorDto.MapDtoToDomainEntity();
        await authorRepository.CreateAsync(authorDto.MapDtoToDomainEntity());
        return author;
    }

    public async Task<GetAuthorDTO> UpdateAuthor(string authorId, AuthorUpdateDTO updatedAuthor)
    {
        //if (int.Parse(authorId) < 0) throw new AuthorInvalidArgumentException(authorId);
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        await authorRepository.UpdateAsync(updatedAuthor.MapDtoToDomainEntity(authorId), authorId);
        return author.MapDomainEntityToDto();
    }
}