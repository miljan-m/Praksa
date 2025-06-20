using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.AuthorQueries;

public record GetOneAuthorQuery(string authorId) : IRequest<Author>;