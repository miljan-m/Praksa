using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteAuthorCommands;


public record DeleteAuthorCommand(string authorId) :IRequest<bool>;