using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.AuthorQueries;


public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<Author>>
{
    IGenericRepository<Author> _authorRepository;
    public GetAllAuthorQueryHandler(IGenericRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public Task<List<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        return _authorRepository.GetAllAsync();
    }
}