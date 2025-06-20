using MediatR;

namespace LibraryApp.Application.CQRS.Queries.GetOne.CustomersQueries;


public record GetOneCustomerQuery(string jmbg) : IRequest<Customer>;