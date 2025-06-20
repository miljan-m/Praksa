using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteAuthorCommands;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
{
    private readonly IGenericRepository<Author> _authorRepository;
    public DeleteAuthorCommandHandler(IGenericRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        return await _authorRepository.DeleteAsync(request.authorId);
    }
}

