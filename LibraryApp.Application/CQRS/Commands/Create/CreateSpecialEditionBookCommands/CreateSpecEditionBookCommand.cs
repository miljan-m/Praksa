using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Create.CreateSpecialEditionBookCommands;


public record CreateSpecialEditionBookCommand(SpecialEditionBook book) : IRequest<SpecialEditionBook>;