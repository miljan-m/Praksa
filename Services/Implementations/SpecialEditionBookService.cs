using LibraryApp.DTOs;
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
        return await context.Books.OfType<SpecialEditionBook>().Select(b=>b.MapDomainEntitiesToDto()).ToListAsync();
    }

    public Task<GetSpecialBookDTO> GetBook(string isbn)
    {
        return context.Books.OfType<SpecialEditionBook>().Where(b => b.Isbn == isbn).Select(b=>b.MapDomainEntityToDto()).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteBook(string isbn)
    {
        var book = await context.Books.FindAsync(isbn);
        if (book == null) return false;
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<GetSpecialBookDTO> CreateBook(CreateSpecialBookDTO bookCreateDTO, int authorId)
    {
        var author = await context.Authors.FindAsync(authorId);
        if (author == null) return null;
        var book = bookCreateDTO.MapDtoToDomainEntity(author);
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
        return book.MapDomainEntityToDto();
    }

    public async Task<GetSpecialBookDTO> UpdateBook(string isbn, UpdateSpecialBookDTO updatedBook)
    {
        var specialBook = await context.Books.OfType<SpecialEditionBook>().Include(b => b.Author).Where(b => b.Isbn == isbn).FirstOrDefaultAsync();
        if (specialBook == null) return null;

        specialBook.Autograph = updatedBook.Autograph;
        specialBook.Available = updatedBook.Available;
        specialBook.Genre = updatedBook.Genre;
        specialBook.InStorage = updatedBook.InStorage;
        specialBook.Title = updatedBook.Title;

        await context.SaveChangesAsync();
        return specialBook.MapDomainEntityToDto();
    }
}