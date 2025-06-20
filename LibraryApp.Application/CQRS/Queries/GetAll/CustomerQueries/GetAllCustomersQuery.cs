using LibraryApp.Application.Services;
using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetAll.CustomerQueries;

public record GetAllCustomersQuery : IRequest<List<Customer>>;