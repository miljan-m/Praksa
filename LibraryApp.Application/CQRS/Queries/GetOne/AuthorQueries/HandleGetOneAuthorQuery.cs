using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.AuthorQueries;


public class HandleGetAllAuthorQuery : IRequestHandler<GetOneAuthorQuery, Author>
{
    IGenericRepository<Author> _authorRepository;
    public HandleGetAllAuthorQuery(IGenericRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<Author> Handle(GetOneAuthorQuery request, CancellationToken cancellationToken)
    {
        return await _authorRepository.GetOneAsync(request.authorId);
    }

   
}