using LibraryApp.DTOs;
using LibraryApp.DTOs.RequestDTO.SpecialEditionBook;
using LibraryApp.DTOs.ResponseDTO.SpecialEditionBook;

namespace LibraryApp.Services;

public interface ISpecialEditionBookService
{
    public Task<IEnumerable<GetSpecialBooksDTO>> GetBooks();
    public Task<GetSpecialBookDTO> GetBook(string isbn);
    public Task<bool> DeleteBook(string isbn);
    public Task<GetSpecialBookDTO> UpdateBook(string isbn, UpdateSpecialBookDTO updatedBook);
    public Task<GetSpecialBookDTO> CreateBook(CreateSpecialBookDTO bookCreateDTO, string authorId);
}