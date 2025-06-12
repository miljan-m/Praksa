using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.SpecialEditionBook;
using LibraryApp.DTOs.ResponseDTO.SpecialEditionBook;

namespace LibraryApp.Mappers;

public static class ExtensionSpecialBookMethods
{
    public static SpecialEditionBook MapDtoToDomainEntity(this CreateSpecialBookDTO bookDto, Author author)
    {
        return new SpecialEditionBook
        {
            Title = bookDto.Title,
            Genre = bookDto.Genre,
            Available = bookDto.Available,
            Author = author,
            AuthorId = author.AuthorId,
            Autograph = bookDto.Autograph,
            InStorage = bookDto.InStorage
        };
    }

    public static SpecialEditionBook MapDtoToDomainEntity(this UpdateSpecialBookDTO bookDto, Author author)
    {
        return new SpecialEditionBook
        {
            Title = bookDto.Title,
            Genre = bookDto.Genre,
            Available = bookDto.Available,
            Author = author,
            AuthorId = author.AuthorId,
            Autograph = bookDto.Autograph,
            InStorage = bookDto.InStorage
        };
    }

    public static GetSpecialBookDTO MapDomainEntityToDto(this SpecialEditionBook book)
    {
        return new GetSpecialBookDTO
        {
            Title = book.Title,
            Available = book.Available,
            Genre = book.Genre,
            InStorage = book.InStorage,
            Autograph = book.Autograph
        };
    }
    
     public static GetSpecialBooksDTO MapDomainEntitiesToDto(this SpecialEditionBook book)
    {
        return new GetSpecialBooksDTO
        {
            Title = book.Title,
            Available = book.Available,
            Genre = book.Genre,
            InStorage = book.InStorage,
            Autograph=book.Autograph    
        };
    }
       
}