using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.SpecialEditionBookQueries;

class GetAllSpecEditionBooksQueryHandler : IRequestHandler<GetAllSpecEditionBooksQuery, List<SpecialEditionBook>>
{

    private readonly IGenericRepository<SpecialEditionBook> _bookRepository;

    public GetAllSpecEditionBooksQueryHandler(IGenericRepository<SpecialEditionBook> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<List<SpecialEditionBook>> Handle(GetAllSpecEditionBooksQuery request, CancellationToken cancellationToken)
    {
        return await _bookRepository.GetAllAsync();
    }
}