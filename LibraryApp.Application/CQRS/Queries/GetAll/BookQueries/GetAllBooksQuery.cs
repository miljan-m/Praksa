using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.BookQueries;

public record GetAllBooksQuery:IRequest<List<Book>>;