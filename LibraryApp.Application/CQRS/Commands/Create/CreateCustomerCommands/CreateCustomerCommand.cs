using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateCustomerCommands;

public record CreateCustomerCommand(Customer customer) : IRequest<Customer>;