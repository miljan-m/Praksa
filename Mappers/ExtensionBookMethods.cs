using LibraryApp.DTOs;

namespace LibraryApp.Mappers;

public static class ExtensionBookMethods
{
    public static Book MapDtoToDomainEntity(this BookCreateDTO bookDTO, Author author)
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

    public static BookDTO MapDomainEntityToDTO(this Book book)
    {
        return new BookDTO
        {
            Isbn = book.Isbn,
            Title = book.Title,
            Genre = book.Genre,
            Available = book.Available,
            AuthorName = book.Author!=null ? book.Author.Name+" "+book.Author.LastName : "NO AUTHOR"
        };     
        
    }



}