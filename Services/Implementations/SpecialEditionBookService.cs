using LibraryApp.CustomExceptions;
using LibraryApp.CustomExceptions.AuthorExceptions;
using LibraryApp.CustomExceptions.BookException;
using LibraryApp.Data.DbRepository;
using LibraryApp.DTOs.RequestDTO.SpecialEditionBook;
using LibraryApp.DTOs.ResponseDTO.SpecialEditionBook;
using LibraryApp.Mappers;

namespace LibraryApp.Services.Implementations;

public class SpecialEditionBookService : ISpecialEditionBookService
{
    private readonly LibraryDBContext context;
    private readonly IGenericRepository<SpecialEditionBook> specEditionBookRepository;
    private readonly IGenericRepository<Author> authorRepository;

    public SpecialEditionBookService(LibraryDBContext context, IGenericRepository<SpecialEditionBook> specEditionBookRepository, IGenericRepository<Author> authorRepository)
    {
        this.context = context;
        this.specEditionBookRepository = specEditionBookRepository;
        this.authorRepository = authorRepository;
    }


    public async Task<IEnumerable<GetSpecialBooksDTO>> GetBooks()
    {
        var booksList = await specEditionBookRepository.GetAllAsync();
        var books = booksList.Select(b => b.MapDomainEntitiesToDto());
        if (booksList == null) throw new NotFoundException("Database is empty");
        return books;
    }

    public async Task<GetSpecialBookDTO> GetBook(string isbn)
    {
        bool isbnValid = true;
        char[] specChar = ['*', '\'', '\\', '+', '*', '/', '.', ',', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '|', '[', ']'];
        for (int i = 0; i < specChar.Length; i++)
        {
            if (isbn.Contains(specChar[i])) isbnValid = false;
        }
        if (isbnValid == false) throw new SpecBookInvalidArgumentException(isbn);
        var book = await specEditionBookRepository.GetOneAsync(isbn);
        if (book == null) throw new SpecBookNotFoundException(isbn);
        return book.MapDomainEntityToDto();
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
        var book = await specEditionBookRepository.GetOneAsync(isbn);
        if (book == null) throw new SpecBookNotFoundException(isbn);
        await specEditionBookRepository.DeleteAsync(isbn);
        return true;
    }
    public async Task<GetSpecialBookDTO> CreateBook(CreateSpecialBookDTO bookCreateDTO, string authorId)
    {
        //if (int.Parse(authorId) < 0) throw new AuthorInvalidArgumentException(authorId);
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        var book = bookCreateDTO.MapDtoToDomainEntity(author);
        await specEditionBookRepository.CreateAsync(bookCreateDTO.MapDtoToDomainEntity(author));
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

        var book = updatedBook.MapDtoToDomainEntity(specialBook.Author);
        book.Isbn = isbn;
        await specEditionBookRepository.UpdateAsync(book, isbn);
        return specialBook.MapDomainEntityToDto();
    }
}