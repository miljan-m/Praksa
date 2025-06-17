using LibraryApp.CustomExceptions;
using LibraryApp.CustomExceptions.AuthorExceptions;
using LibraryApp.CustomExceptions.BookException;
using LibraryApp.Data.DbRepository;
using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Book;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class BookService : IBookService
{
    private readonly LibraryDBContext context;
    private readonly IGenericRepository<Book> bookRepository;
    private readonly IGenericRepository<Author> authorRepository;
    public BookService(LibraryDBContext context, IGenericRepository<Book> bookRepository, IGenericRepository<Author> authorRepository)
    {
        this.context = context;
        this.bookRepository = bookRepository;
        this.authorRepository = authorRepository;
    }

    public async Task<IEnumerable<GetBooksDTO>> GetBooks()
    {
        var booksList = await bookRepository.GetAllAsync();
        var books = booksList.Select(b => b.MapDomainEntitiesToDTO());
        if (booksList == null) throw new NotFoundException("Database is empty");
        return books;
    }

    public async Task<GetBookDTO> GetBook(string isbn)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new BookInvalidArgumentException(isbn);
        var book = await bookRepository.GetOneAsync(isbn);
        if (book == null) throw new BookNotFoundException(isbn);
        return book.MapDomainEntityToDTO();
    }

    public async Task<GetBookDTO> CreateBook(BookCreateDTO bookCreateDTO, string authorId)
    {
        //if (int.Parse(authorId) < 0) throw new AuthorInvalidArgumentException(authorId);
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        var book = bookCreateDTO.MapDtoToDomainEntity(author);

        await bookRepository.CreateAsync(book);

        return book.MapDomainEntityToDTO();
    }

    public async Task<bool> DeleteBook(string isbn)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new BookInvalidArgumentException(isbn);
        var book = await bookRepository.GetOneAsync(isbn);
        if (book == null)  throw new BookNotFoundException(isbn);
        await bookRepository.DeleteAsync(isbn);
        return true; 

    }

    public  async Task<GetBookDTO> UpdateBook(string isbn, BookUpdateDTO updatedBook)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false)  throw new BookInvalidArgumentException(isbn);

        var book =  context.Books
                    .OfType<Book>()
                    .Include(a => a.Author)
                    .FirstOrDefault(b => b.Isbn == isbn);

        
        if (book == null) throw new BookNotFoundException(isbn);
        var updatedBookToEntity = updatedBook.MapDtoToDomainEntity(book.Author);
        updatedBookToEntity.Isbn = isbn;
        await bookRepository.UpdateAsync(updatedBookToEntity, isbn);
        return book.MapDomainEntityToDTO();
    }
}