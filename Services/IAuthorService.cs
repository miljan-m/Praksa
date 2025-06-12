using LibraryApp.DTOs.RequestDTO.Author;
using LibraryApp.DTOs.ResponseDTO.Author;

namespace LibraryApp.Services;

public interface IAuthorService
{
    public Task<IEnumerable<GetAuthorsDTO>> GetAuthors();
    public Task<Author> GetAuthor(int authorId);
    public Task<bool> DeleteAuthor(int authorId);
    public Task<Author> CreateAuthor(AuthorCreateDTO authorDto);
    public Task<GetAuthorDTO> UpdateAuthor(int authorId, AuthorUpdateDTO updatedAuthor);
}