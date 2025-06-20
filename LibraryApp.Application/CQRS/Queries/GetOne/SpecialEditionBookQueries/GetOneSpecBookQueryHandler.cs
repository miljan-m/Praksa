using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.SpecialEditionBookQueries;

class GetOneSpecBookQueryHandler : IRequestHandler<GetOneSpecBookQuery, Book>
{

    private readonly IGenericRepository<SpecialEditionBook> _bookRepository;

    public GetOneSpecBookQueryHandler(IGenericRepository<SpecialEditionBook> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<Book> Handle(GetOneSpecBookQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetOneAsync(request.isbn);
    }
}