using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateBookCommands;

public record UpdateBookCommand(Book book,string isbn):IRequest<Book>;