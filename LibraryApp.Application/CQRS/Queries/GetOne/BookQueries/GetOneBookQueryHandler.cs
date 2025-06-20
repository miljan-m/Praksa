using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.BookQueries;

public class GetOneBookQueryHandler : IRequestHandler<GetOneBookQuery, Book>
{
    
    private readonly IGenericRepository<Book> _bookRepository;

    public GetOneBookQueryHandler(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<Book> Handle(GetOneBookQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetOneAsync(request.isbn);
    }
}