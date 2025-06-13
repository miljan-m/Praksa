using LibraryApp.CustomExceptions;
using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.Book;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class BookService : IBookService
{
    private readonly LibraryDBContext context;

    public BookService(LibraryDBContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<GetBooksDTO>> GetBooks()
    {
        var books = await context.Books.OfType<Book>().Include(a => a.Author).Select(b => b.MapDomainEntitiesToDTO()).ToListAsync();
        if (books == null) throw new NotFoundException("Database is empty");
        return books;
    }

    public async Task<GetBookDTO> GetBook(string isbn)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '-', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '-', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new InvalidArgumentException("ISBN is not valid");
        var book = await context.Books.Where(b => b.Isbn == isbn).Select(b => b.MapDomainEntityToDTO()).FirstOrDefaultAsync();
        if (book == null) throw new NotFoundException("Book can't be found");
        return book;
    }

    public async Task<GetBookDTO> CreateBook(BookCreateDTO bookCreateDTO, int authorId)
    {
        if (authorId < 0) throw new InvalidArgumentException("Author's id not valid");
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) throw new NotFoundException("Author can't be found");
        var book = bookCreateDTO.MapDtoToDomainEntity(author);

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return book.MapDomainEntityToDTO();
    }

    public async Task<bool> DeleteBook(string isbn)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '-', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '-', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new InvalidArgumentException("ISBN is not valid");
        var book = await context.Books.FindAsync(isbn);
        if (book == null) throw new NotFoundException("Book can't be found");
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true; 

    }

    public  async Task<GetBookDTO> UpdateBook(string isbn, BookUpdateDTO updatedBook)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '-', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '-', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new InvalidArgumentException("ISBN is not valid");
       
        var book =  context.Books
                    .OfType<Book>()
                    .Include(a => a.Author)
                    .FirstOrDefault(b => b.Isbn == isbn);
        if (book == null) throw new NotFoundException("Book can't be found");

        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        await context.SaveChangesAsync();
        return book.MapDomainEntityToDTO();
    }
}