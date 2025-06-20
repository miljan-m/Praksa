using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateBookCommands;

public record CreateBookCommand(Book book):IRequest<Book>;