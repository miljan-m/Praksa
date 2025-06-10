using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface IAuthorService
{
    public Task<IEnumerable<Author>> GetAuthors();
    public Task<Author> GetAuthor(int authorId);
    public Task<bool> DeleteAuthor(int authorId);
    public Task<Author> CreateAuthor(AuthorCreateDTO authorDto);
    public Task<Author> UpdateAuthor(int authorId, AuthorUpdateDTO updatedAuthor);
}