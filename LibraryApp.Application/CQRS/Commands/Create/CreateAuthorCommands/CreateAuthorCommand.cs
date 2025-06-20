using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateAuthorCommands;

public record CreateAuthorCommand(Author author):IRequest<Author>;