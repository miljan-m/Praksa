using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateSpecialEditionBookCommands;

public record UpdateSpecEditionBookCommand(SpecialEditionBook book,string isbn):IRequest<SpecialEditionBook>;