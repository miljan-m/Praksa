using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.SpecialEditionBookQueries;


public record GetAllSpecEditionBooksQuery : IRequest<List<SpecialEditionBook>>;