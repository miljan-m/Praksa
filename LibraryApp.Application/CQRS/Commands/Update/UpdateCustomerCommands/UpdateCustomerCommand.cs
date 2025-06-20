using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateCustomerCommands;


public record UpdateCustomerCommand(Customer cutomer,string jmbg) : IRequest<Customer>;