
namespace LibraryApp.ExtensionClasses;

public static class ExtensionAuthorMethods
{

    public static IQueryable<AuthorDTO> GetAllAuthors(this LibraryDBContext context)
    {
        return context.Authors.Select(a => new AuthorDTO
        {
            Name = a.Name,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth,
            Books = a.Books
        });

    }

    public static Author GetOneAuthor(this LibraryDBContext context, int authorId)
    {
        return context.Authors
                .Where(a => a.AuthorId == authorId)
                .FirstOrDefault();
    }

    public static AuthorDTO MapAuthorToDTO(this Author a)
    {
        return new AuthorDTO
        {
            Name = a.Name,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth,
        };
    }

    public static Author MapDtoToAuthor(this Author author, AuthorCreateDTO authorToCreate)
    {
        return new Author
        {
            Name = authorToCreate.Name,
            LastName = authorToCreate.LastName,
            DateOfBirth = authorToCreate.DateOfBirth
        };

    }

    public static void UpdateAuthor(this Author author, AuthorUpdateDTO authorDto)
    {
        author.Name = authorDto.Name;
        author.LastName = authorDto.LastName;
        author.DateOfBirth = authorDto.DateOfBirth;
    }

}