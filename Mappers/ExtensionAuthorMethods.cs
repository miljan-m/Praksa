using LibraryApp.DTOs.RequestDTO.Author;
using LibraryApp.DTOs.ResponseDTO.Author;

namespace LibraryApp.Mappers;

public static class ExtensionAuthorMethods
{
    public static GetAuthorsDTO MapDomainEntitiesToDto(this Author a)
    {
        return new GetAuthorsDTO
        {
            Name = a.Name,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth,
        };
    }

     public static GetAuthorDTO MapDomainEntityToDto(this Author a)
    {
        return new GetAuthorDTO
        {
            Name = a.Name,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth,
        };
    }

    public static Author MapDtoToDomainEntity(this AuthorCreateDTO authorDto)
    {
        return new Author
        {
            Name = authorDto.Name,
            LastName = authorDto.LastName,
            DateOfBirth = authorDto.DateOfBirth
        };

    }

     public static Author MapDtoToDomainEntity(this AuthorUpdateDTO authorDto)
    {
        return new Author
        {
            Name = authorDto.Name,
            LastName = authorDto.LastName,
            DateOfBirth = authorDto.DateOfBirth
        };

    }

}