using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.BookQueries;

public record GetOneBookQuery(string isbn):IRequest<Book>;