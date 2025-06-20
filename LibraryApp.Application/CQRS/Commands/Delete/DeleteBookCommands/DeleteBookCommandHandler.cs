using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteBookCommands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IGenericRepository<Book> _bookRepository;

    public DeleteBookCommandHandler(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.DeleteAsync(request.isbn);
    }
}