using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteBookCommands;

public record DeleteBookCommand(string isbn) :IRequest<bool>;