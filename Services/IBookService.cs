using LibraryApp.DTOs;

namespace LibraryApp.Services;

public interface IBookService
{

    public Task<IEnumerable<Book>> GetBooks();
    public Task<Book> GetBook(string isbn);

    public Task<bool> DeleteBook(string isbn);

    public Task<Book> UpdateBook(string isbn,BookUpdateDTO updatedBook);

    public Task<BookDTO> CreateBook(BookCreateDTO bookCreateDTO,int authorId);
}