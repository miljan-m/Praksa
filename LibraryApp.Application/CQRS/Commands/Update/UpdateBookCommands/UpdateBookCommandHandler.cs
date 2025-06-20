using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateBookCommands;


public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
{
    private readonly IGenericRepository<Book> _bookRepository;

    public UpdateBookCommandHandler(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.UpdateAsync(request.book,request.isbn);
    }
}