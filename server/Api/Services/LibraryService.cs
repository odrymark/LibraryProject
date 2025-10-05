using System.ComponentModel.DataAnnotations;
using Api.DTOs.Get;
using Api.DTOs.Response;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class LibraryService(LibraryDbContext context) : ILibraryService
{
    public async Task<IEnumerable<BookResDto>> GetAllBooks()
    {
        return await context.Books
            .Include(b => b.authors) 
            .Select(b => new BookResDto
            {
                id = b.id,
                title = b.title,
                pages = b.pages,
                genre = context.Genres.FirstOrDefault(g => g.id == b.genreid).name,
                author = b.authors.Select(a => a.name).ToList() 
            })
            .ToListAsync();
    }

    public async Task<BookResDto?> GetBookById(int id)
    {
        return await context.Books
            .Include(b => b.authors)
            .Where(b => b.id == id)
            .Select(b => new BookResDto
            {
                id = b.id,
                title = b.title,
                pages = b.pages,
                genre = context.Genres.FirstOrDefault(g => g.id == b.genreid).name,
                author = b.authors.Select(a => a.name).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<GenreResDto>> GetAllGenres()
    {
        return await context.Genres
            .Select(g => new GenreResDto
            {
                id = g.id,
                name = g.name,
                numOfBooks = g.books.Count()
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<AuthorResDto>> GetAllAuthors()
    {
        return await context.Authors
            .Select(a => new AuthorResDto
            {
                id = a.id,
                name = a.name,
                numOfBooks = a.books.Count()
            })
            .ToListAsync();
    }
    
    public async Task<int> AddBook(BookGetDto dto)
    {
        var authors = new List<Author>();
        
        foreach (var authorName in dto.author) 
        {
            var author = await GetBookAuthor(authorName);
            authors.Add(author);
        }
        
        var genre = await GetBookGenre(dto.genre);
        var newBook = new Book
        {
            title = dto.title,
            pages = dto.pages,
            genreid = genre.id,
            authors = authors
        };
        
        context.Books.Add(newBook);
        await context.SaveChangesAsync();
        
        return newBook.id;
    }
    
    private async Task<Author> GetBookAuthor(string authorName)
    {
        var author = await context.Authors
            .FirstOrDefaultAsync(a => a.name == authorName);

        if (author == null)
        {
            author = new Author { name = authorName };
            context.Authors.Add(author);
            await context.SaveChangesAsync(); 
        }
        
        return author;
    }

    private async Task<Genre> GetBookGenre(string genreName)
    {
        var genre = await context.Genres
            .FirstOrDefaultAsync(g => g.name == genreName);

        if (genre == null)
        {
            genre = new Genre { name = genreName };
            context.Genres.Add(genre);
            await context.SaveChangesAsync(); 
        }
        
        return genre;
    }
}