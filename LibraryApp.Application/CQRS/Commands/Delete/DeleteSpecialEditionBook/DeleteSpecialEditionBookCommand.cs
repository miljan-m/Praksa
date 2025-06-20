using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Delete.DeleteSpecialEditionBook;

public record DeleteSpecEditionBookCommand(string isbn) :IRequest<bool>;