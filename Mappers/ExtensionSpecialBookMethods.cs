using LibraryApp.DTOs;

namespace LibraryApp.Mappers;

public static class ExtensionSpecialBookMethods
{
    public static SpecialEditionBook MapDtoToDomainEntity(this SpecialEditionBookCreateDTO bookDto,Author author)
    {
        return new SpecialEditionBook
        {
            Title = bookDto.Title,
            Genre = bookDto.Genre,
            Available = bookDto.Available,
            Author = author,
            AuthorId = author.AuthorId,
            Autograph = bookDto.Autograph,
            InStorage=bookDto.InStorage
        };
    }

    public static SpecialEditionBookDTO MapDomainEntityToDto(this SpecialEditionBook book)
    {
        return new SpecialEditionBookDTO
        {
            Isbn = book.Isbn,
            Title = book.Title,
            Available = book.Available,
            Genre = book.Genre,
            InStorage = book.InStorage,
            AuthorName = book.Author != null ? book.Author.Name + " " + book.Author.LastName : "NO AUTHOR",
            Autograph=book.Autograph    
        };
    }
       
}