using Api.Controllers;
using Api.DTOs.Get;
using Api.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests;

public class LibraryControllerTests : LibraryControllerTestsBase
{

    [Fact]
    public void GetBooksAll_ReturnsAllBooks()
    {
        var result = _controller.GetAllBooks();
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        var books = Assert.IsAssignableFrom<IQueryable<BookResDto>>(okResult.Value);
        
        Assert.Equal(2, books.Count());
    }

    [Fact]
    public void GetBookById_ValidId_ReturnsBook()
    {
        var result = _controller.GetBookById(1);
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        var book = Assert.IsType<BookResDto>(okResult.Value);
        
        Assert.Equal("The Hobbit", book.title);
        Assert.Equal("Fantasy", book.genre);
    }

    [Fact]
    public void GetBookById_InvalidId_ReturnsNotFound()
    {
        var result = _controller.GetBookById(999);
        
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetGenres_ReturnsGenresWithBookCounts()
    {
        var result = _controller.GetGenres();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var genres = Assert.IsAssignableFrom<IQueryable<GenreResDto>>(okResult.Value);

        Assert.Equal(2, genres.Count());
        
        Assert.Contains(genres, g => g.numOfBooks > 0);
    }

    [Fact]
    public void GetAuthors_ReturnsAuthorsWithBookCounts()
    {
        var result = _controller.GetAuthors();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var authors = Assert.IsAssignableFrom<IQueryable<AuthorResDto>>(okResult.Value);
        
        Assert.Equal(2, authors.Count());
        
        Assert.Contains(authors, a => a.numOfBooks > 0);
    }

    [Fact]
    public void AddBook_ValidBook_AddsAndReturnsBooks()
    {
        var dto = new BookGetDto
        {
            title = "New Book",
            pages = 123,
            author = ["New Author1", "New Author2"],
            genre = "New Genre"
        };

        var result = _controller.AddBook(dto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var books = Assert.IsAssignableFrom<IQueryable<BookResDto>>(okResult.Value);
        
        Assert.Contains("New Book", books.Select(b => b.title));
    }

    [Fact]
    public void AddBook_InvalidBook_ReturnsBadRequest()
    {
        var dto = new BookGetDto
        {
            title = "", pages = -1, author = [""], genre = ""
        };

        var result = _controller.AddBook(dto);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}