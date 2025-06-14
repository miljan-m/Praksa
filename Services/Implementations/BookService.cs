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
        return await context.Books.OfType<Book>().Include(a=>a.Author).Select(b=>b.MapDomainEntitiesToDTO()).ToListAsync();
    }

    public async Task<GetBookDTO> GetBook(string isbn)
    {
        return await context.Books.Where(b => b.Isbn == isbn).Select(b => b.MapDomainEntityToDTO()).FirstOrDefaultAsync();
    }

    public async Task<GetBookDTO> CreateBook(BookCreateDTO bookCreateDTO, int authorId)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) return null;
        var book = bookCreateDTO.MapDtoToDomainEntity(author);

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return book.MapDomainEntityToDTO();
    }

    public async Task<bool> DeleteBook(string isbn)
    {
        var book = await context.Books.FindAsync(isbn);
        if (book == null) return false;
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true; 

    }

    public  async Task<GetBookDTO> UpdateBook(string isbn, BookUpdateDTO updatedBook)
    {
        var book =  context.Books
                    .OfType<Book>()
                    .Include(a => a.Author)
                    .FirstOrDefault(b => b.Isbn == isbn);
        if (book == null) return null;

        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        await context.SaveChangesAsync();
        return book.MapDomainEntityToDTO();
    }
}