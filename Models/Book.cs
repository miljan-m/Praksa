using System.ComponentModel.DataAnnotations;
using LibraryApp.DTOs;
using LibraryApp.Mappers;
using LibraryApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryApp.Models;

public class Book :IBookService
{
    [Key]
    public string Isbn { get; set; }
    public string Title { get; set; }

    public string Genre { get; set; }
    public bool Available { get; set; }
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }
    
    private readonly LibraryDBContext context;

    public Book()
    {
        
    }

    public Book(LibraryDBContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await context.Books.ToListAsync();
    }

     public async Task<Book> GetBook(string isbn)
    {
        return await context.Books.FindAsync(isbn);
    }

    public async Task<BookDTO> CreateBook(BookCreateDTO bookCreateDTO, int authorId)
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

    public  async Task<Book> UpdateBook(string isbn, BookUpdateDTO updatedBook)
    {
        var book =  context.Books
                    .Include(a => a.Author)
                    .FirstOrDefault(b => b.Isbn == isbn);
        if (book == null) return null;
        if (book.Author == null) return null;

        book.Title = updatedBook.Title;
        book.Genre = updatedBook.Genre;
        book.Available = updatedBook.Available;
        await context.SaveChangesAsync();
        return book;
    }
}