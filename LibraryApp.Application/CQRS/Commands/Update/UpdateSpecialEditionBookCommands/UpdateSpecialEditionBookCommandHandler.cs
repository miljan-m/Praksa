using LibraryApp.Application.Services;
using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateSpecialEditionBookCommands;


public class UpdateSpecEditionBookCommandHandler : IRequestHandler<UpdateSpecEditionBookCommand, Book>
{
    private readonly IGenericRepository<SpecialEditionBook> _bookRepository;

    public UpdateSpecEditionBookCommandHandler(IGenericRepository<SpecialEditionBook> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<Book> Handle(UpdateSpecEditionBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.UpdateAsync(request.book,request.isbn);
    }
}