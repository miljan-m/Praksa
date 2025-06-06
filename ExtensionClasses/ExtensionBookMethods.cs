
namespace LibraryApp.ExtensionClasses;

public static class ExtensionBookMethods
{
    public static IQueryable<BookDTO> GetAllBooks(this LibraryDBContext context)
    {
        return context.Books.Select(b => new BookDTO
        {
            Title = b.Title,
            Isbn = b.Isbn,
            Genre = b.Genre,
            Available = b.Available,
            AuthorName = b.Author == null ? "NEMA AUTORA" : b.Author.Name
        });
    }

    public static BookDTO GetOneBook(this LibraryDBContext context, string isbn)
    {
        return context.Books.Where(b => b.Isbn == isbn).Select(b => new BookDTO
        {
            Title = b.Title,
            Isbn = b.Isbn,
            Genre = b.Genre,
            Available = b.Available,
            AuthorName = b.Author == null ? "NEMA AUTORA" : b.Author.Name
        }).FirstOrDefault();
    }

    public static Book MapDtoToBook(BookCreateDTO bookDTO, Author author)
    {
        return new Book
        {
            Isbn = bookDTO.Isbn,
            Title = bookDTO.Title,
            Genre = bookDTO.Genre,
            Available = bookDTO.Available,
            AuthorId = author.AuthorId,
            Author = author
        };
    }

    public static BookDTO MapBookToDTO(this Book book)
    {
        return new BookDTO
        {
            Isbn = book.Isbn,
            Title = book.Title,
            Genre = book.Genre,
            Available = book.Available,
            AuthorName = book.Author.Name
        };
    }

    public static Book GetFullBook(this LibraryDBContext context, string isbn)
    {
        return context.Books.Include(a => a.Author).FirstOrDefault(b => b.Isbn == isbn);
    }

    public static BookDTO MapBookToBookDTO(this Book book)
    {
        return new BookDTO
        {
            Isbn = book.Isbn,
            Title = book.Title,
            Genre = book.Genre,
            Available = book.Available,
            AuthorName = book.Author.Name,
        };
    }
}