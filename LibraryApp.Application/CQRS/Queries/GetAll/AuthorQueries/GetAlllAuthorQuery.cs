using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.AuthorQueries;

public record GetAllAuthorQuery : IRequest<List<Author>>;