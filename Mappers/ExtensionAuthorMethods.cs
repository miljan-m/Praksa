namespace LibraryApp.Mappers;

public static class ExtensionAuthorMethods
{
    public static AuthorDTO MapDomainEntityToDto(this Author a)
    {
        return new AuthorDTO
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
            DateOfBirth=authorDto.DateOfBirth
        };

    }

   

}