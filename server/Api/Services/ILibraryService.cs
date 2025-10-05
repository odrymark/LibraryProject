using Api.DTOs.Get;
using Api.DTOs.Response;
using DataAccess;

namespace Api.Services;

public interface ILibraryService
{
    Task<IEnumerable<BookResDto>> GetAllBooks();
    Task<BookResDto?> GetBookById(int id);
    Task<IEnumerable<GenreResDto>> GetAllGenres();
    Task<IEnumerable<AuthorResDto>> GetAllAuthors();
    Task<int> AddBook(BookGetDto dto);
}