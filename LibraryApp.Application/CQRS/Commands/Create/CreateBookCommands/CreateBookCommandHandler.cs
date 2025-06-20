using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateBookCommands;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
{
    private readonly IGenericRepository<Book> _bookRepository;

    public CreateBookCommandHandler(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.CreateAsync(request.book);
    }
}