using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateAdminCommands;

public record UpdateAdminCommand(string adminId, Admin admin) : IRequest<Admin>;