using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface ISpecialEditionBookService
{
    public Task<IEnumerable<SpecialEditionBookDTO>> GetBooks();
    public Task<SpecialEditionBookDTO> GetBook(string isbn);
    public Task<bool> DeleteBook(string isbn);
    public Task<SpecialEditionBookDTO> UpdateBook(string isbn, SpecialEditionBookCreateDTO updatedBook);
    public Task<SpecialEditionBookDTO> CreateBook(SpecialEditionBookCreateDTO bookCreateDTO, int authorId);
}