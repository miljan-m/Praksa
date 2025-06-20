using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.SpecialEditionBookQueries;

public record GetOneSpecBookQuery(string isbn):IRequest<Book>;