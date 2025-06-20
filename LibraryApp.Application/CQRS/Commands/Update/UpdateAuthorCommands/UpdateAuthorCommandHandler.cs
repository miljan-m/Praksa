using LibraryApp.Application.Mappers;
using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateAuthorCommands;

public class UpdateAuthorCommandhandler : IRequestHandler<UpdateAuthorCommand, Author>
{
    private readonly IGenericRepository<Author> _authorRepository;
    public UpdateAuthorCommandhandler(IGenericRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
       return await _authorRepository.UpdateAsync(request.updatedAuthor.MapDtoToDomainEntity(request.author), request.authorId);
       
    }
}