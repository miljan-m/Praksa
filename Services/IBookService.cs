using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface IBookService
{
    public Task<IEnumerable<BookDTO>> GetBooks();
    public Task<BookDTO> GetBook(string isbn);
    public Task<bool> DeleteBook(string isbn);
    public Task<BookDTO> UpdateBook(string isbn, BookUpdateDTO updatedBook);
    public Task<BookDTO> CreateBook(BookCreateDTO bookCreateDTO, int authorId);
}