using LibraryApp.Application.Interfaces;
using LibraryApp.Mappers;
using LibraryApp.Application.CustomExceptions;
using LibraryApp.Application.Mappers;
using MediatR;
using LibraryApp.Application.CQRS.Queries.GetOne.AuthorQueries;
using LibraryApp.Application.CQRS.Queries.GetAll.AuthorQueries;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteAuthorCommands;
using LibraryApp.Application.CQRS.Commands.Update.UpdateAuthorCommands;

namespace LibraryApp.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IGenericRepository<Author> authorRepository;
    private readonly IMediator mediator;
    public AuthorService(IGenericRepository<Author> authorRepository,IMediator mediator)
    {
        this.authorRepository = authorRepository;
        this.mediator = mediator;

    }

    public async Task<IEnumerable<GetAuthorsDTO>> GetAuthors()
    {
        var authors = await mediator.Send(new GetAllAuthorQuery());
        var authorsDto = authors.Select(a => a.MapDomainEntitiesToDto());
        if (authors == null) throw new NotFoundException("Database is empty");
        return authorsDto;
    }

    public async Task<Author> GetAuthor(string authorId)
    {
        var author = await mediator.Send(new GetOneAuthorQuery(authorId));
        if (author == null) throw new AuthorNotFoundException(authorId);
        return author;
    }

    public async Task<bool> DeleteAuthor(string authorId)
    {
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        return await mediator.Send(new DeleteAuthorCommand(authorId));
    }

    public async Task<Author> CreateAuthor(AuthorCreateDTO authorDto)
    {
        var author = authorDto.MapDtoToDomainEntity();
        await authorRepository.CreateAsync(author);
        return author;
    }

    public async Task<GetAuthorDTO> UpdateAuthor(string authorId, AuthorUpdateDTO updatedAuthor)
    {
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        await mediator.Send(new UpdateAuthorCommand(authorId,updatedAuthor,author));
        return author.MapDomainEntityToDto();
    }
}