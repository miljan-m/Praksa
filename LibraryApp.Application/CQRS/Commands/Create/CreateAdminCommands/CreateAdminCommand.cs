using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.CreateAdminCommands;

public record CreateAdminCommand(Admin admin) : IRequest<Admin>;