using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteCustomerCommands;

public record DeleteCustomerCommand(string jmbg) : IRequest<bool>; 