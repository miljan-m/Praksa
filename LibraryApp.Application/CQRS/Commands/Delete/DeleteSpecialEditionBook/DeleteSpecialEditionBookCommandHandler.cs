using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteSpecialEditionBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteSpecEditionBookCommand, bool>
{
    private readonly IGenericRepository<SpecialEditionBook> _bookRepository;

    public DeleteBookCommandHandler(IGenericRepository<SpecialEditionBook> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<bool> Handle(DeleteSpecEditionBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.DeleteAsync(request.isbn);
    }
}