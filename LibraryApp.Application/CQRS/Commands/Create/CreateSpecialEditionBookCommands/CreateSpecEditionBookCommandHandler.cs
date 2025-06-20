using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateSpecialEditionBookCommands;

public class CreateBookCommandHandler : IRequestHandler<CreateSpecialEditionBookCommand, SpecialEditionBook>
{
    private readonly IGenericRepository<SpecialEditionBook> _bookRepository;

    public CreateBookCommandHandler(IGenericRepository<SpecialEditionBook> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<SpecialEditionBook> Handle(CreateSpecialEditionBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.CreateAsync(request.book);
    }
}