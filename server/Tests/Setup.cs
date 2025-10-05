using Api.Controllers;
using Api.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public abstract class LibraryControllerTestsBase : IDisposable
{
    protected readonly LibraryDbContext _context;
    protected readonly LibraryService _service;
    protected readonly LibraryController _controller;

    protected LibraryControllerTestsBase()
    {
        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        _context = new LibraryDbContext(options);
        SeedDatabase();

        _service = new LibraryService(_context);
        _controller = new LibraryController(_service);
    }

    private void SeedDatabase()
    {
        var genre1 = new Genre { id = 1, name = "Fantasy" };
        var genre2 = new Genre { id = 2, name = "Sci-Fi" };
        var author1 = new Author { id = 1, name = "J.R.R. Tolkien" };
        var author2 = new Author { id = 2, name = "Isaac Asimov" };
        var book1 = new Book { id = 1, title = "The Hobbit", pages = 310, genreid = 1, authors = new List<Author> { author1 } };
        var book2 = new Book { id = 2, title = "Foundation", pages = 255, genreid = 2, authors = new List<Author> { author2 } };

        _context.Genres.AddRange(genre1, genre2);
        _context.Authors.AddRange(author1, author2);
        _context.Books.AddRange(book1, book2);
        _context.SaveChanges();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}