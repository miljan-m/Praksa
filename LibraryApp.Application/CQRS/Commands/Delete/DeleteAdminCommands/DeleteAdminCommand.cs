using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteAdminCommands;

public record DeleteAdminCommand(string AdminId) : IRequest<bool>;