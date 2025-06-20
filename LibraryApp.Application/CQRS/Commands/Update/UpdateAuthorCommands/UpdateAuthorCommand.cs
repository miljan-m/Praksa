using MediatR;

namespace LibraryApp.Application.CQRS.Commands.Update.UpdateAuthorCommands;

public record UpdateAuthorCommand(string authorId, AuthorUpdateDTO updatedAuthor,Author author):IRequest<Author>;