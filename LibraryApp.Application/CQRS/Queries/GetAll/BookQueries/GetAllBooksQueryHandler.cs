using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.BookQueries;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery,List<Book>>
{
    private readonly IGenericRepository<Book> _bookRepository;

    public GetAllBooksQueryHandler(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetAllAsync();
    }

    
}