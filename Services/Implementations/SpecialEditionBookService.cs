using LibraryApp.CustomExceptions;
using LibraryApp.CustomExceptions.AuthorExceptions;
using LibraryApp.CustomExceptions.BookException;
using LibraryApp.DTOs.RequestDTO.SpecialEditionBook;
using LibraryApp.DTOs.ResponseDTO.SpecialEditionBook;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class SpecialEditionBookService : ISpecialEditionBookService
{
     private readonly LibraryDBContext context;

    public SpecialEditionBookService(LibraryDBContext context)
    {
        this.context = context;
    }


    public async Task<IEnumerable<GetSpecialBooksDTO>> GetBooks()
    {
        var books= await context.Books.OfType<SpecialEditionBook>().Select(b => b.MapDomainEntitiesToDto()).ToListAsync();
        if (books == null) throw new NotFoundException("Database is empty");
        return books;
    }

    public Task<GetSpecialBookDTO> GetBook(string isbn)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new SpecBookInvalidArgumentException(isbn);
        var book = context.Books.OfType<SpecialEditionBook>().Where(b => b.Isbn == isbn).Select(b => b.MapDomainEntityToDto()).FirstOrDefaultAsync();
        if (book == null) throw new SpecBookNotFoundException(isbn);
        return book;
    }

    public async Task<bool> DeleteBook(string isbn)
    {   
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new SpecBookInvalidArgumentException(isbn);
        var book = await context.Books.FindAsync(isbn);
        if (book == null) throw new SpecBookNotFoundException(isbn);
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<GetSpecialBookDTO> CreateBook(CreateSpecialBookDTO bookCreateDTO, int authorId)
    {
        if (authorId < 0) throw new AuthorInvalidArgumentException(authorId);
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        var book = bookCreateDTO.MapDtoToDomainEntity(author);
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
        return book.MapDomainEntityToDto();
    }

    public async Task<GetSpecialBookDTO> UpdateBook(string isbn, UpdateSpecialBookDTO updatedBook)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+','*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new SpecBookInvalidArgumentException(isbn);
       
        var specialBook = await context.Books.OfType<SpecialEditionBook>().Include(b => b.Author).Where(b => b.Isbn == isbn).FirstOrDefaultAsync();
        if (specialBook == null) throw new SpecBookNotFoundException(isbn);

        specialBook.Autograph = updatedBook.Autograph;
        specialBook.Available = updatedBook.Available;
        specialBook.Genre = updatedBook.Genre;
        specialBook.InStorage = updatedBook.InStorage;
        specialBook.Title = updatedBook.Title;

        await context.SaveChangesAsync();
        return specialBook.MapDomainEntityToDto();
    }
}