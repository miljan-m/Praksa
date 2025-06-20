using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateAuthorCommands;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
{

    private readonly IGenericRepository<Author> _authorRepository;
    public CreateAuthorCommandHandler(IGenericRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        return await _authorRepository.CreateAsync(request.author);
    }
}

