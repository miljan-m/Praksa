using LibraryApp.Application.Interfaces;
using LibraryApp.Mappers;
using LibraryApp.Application.CustomExceptions;
using MediatR;
using LibraryApp.Application.CQRS.Queries.GetAll.BookQueries;
using LibraryApp.Application.CQRS.Queries.GetOne.BookQueries;
using LibraryApp.Application.CQRS.Commands.Create.CreateBookCommands;
using LibraryApp.Application.CQRS.Commands.Delete.DeleteBookCommands;
using LibraryApp.Application.CQRS.Commands.Update.UpdateBookCommands;

namespace LibraryApp.Application.Services;

public class BookService : IBookService
{
    
    private readonly IGenericRepository<Book> bookRepository;
    private readonly IGenericRepository<Author> authorRepository;
    private readonly IMediator mediator;
    public BookService(IGenericRepository<Book> bookRepository, IGenericRepository<Author> authorRepository, IMediator mediator)
    {

        this.bookRepository = bookRepository;
        this.authorRepository = authorRepository;
        this.mediator = mediator;
    }

    public async Task<IEnumerable<GetBooksDTO>> GetBooks()
    {
        var booksList = await mediator.Send(new GetAllBooksQuery());
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
        var book = await mediator.Send(new GetOneBookQuery(isbn));
        if (book == null) throw new BookNotFoundException(isbn);
        return book.MapDomainEntityToDTO();
    }

    public async Task<GetBookDTO> CreateBook(BookCreateDTO bookCreateDTO, string authorId)
    {
        var author = await authorRepository.GetOneAsync(authorId);
        if (author == null) throw new AuthorNotFoundException(authorId);
        var book = bookCreateDTO.MapDtoToDomainEntity(author);

        await mediator.Send(new CreateBookCommand(book));

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
        await mediator.Send(new DeleteBookCommand(isbn));
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

        // var book =  context.Books
        //             .OfType<Book>()
        //             .Include(a => a.Author)
        //             .FirstOrDefault(b => b.Isbn == isbn);

        var book =await bookRepository.GetOneAsync(isbn);

        
        if (book == null) throw new BookNotFoundException(isbn);
        var updatedBookToEntity = updatedBook.MapDtoToDomainEntity(book);
        updatedBookToEntity.Isbn = isbn;
        await mediator.Send(new UpdateBookCommand(updatedBookToEntity,isbn));
        return book.MapDomainEntityToDTO();
    }
}