using System.ComponentModel.DataAnnotations;
using Api.DTOs.Get;
using Api.DTOs.Response;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("library")]
public class LibraryController(ILibraryService service) : ControllerBase
{
    [HttpGet("books")]
    public async Task<ActionResult> GetAllBooks()
    {
        var books =  await service.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("books/{id}", Name = "GetBookById")]
    public async Task<ActionResult> GetBookById(int id)
    {
        var book = await service.GetBookById(id);
        if (book == null)
            return NotFound();
        
        return Ok(book);
    }

    [HttpGet("genres")]
    public async Task<ActionResult> GetGenres()
    {
        var genres =  await service.GetAllGenres();
        return Ok(genres);
    }
    
    [HttpGet("authors")]
    public async Task<ActionResult> GetAuthors()
    {
        var authors =  await service.GetAllAuthors();
        return Ok(authors);
    }

    [HttpPost("addBook")]
    public async Task<ActionResult> AddBook([FromBody] BookGetDto dto)
    {
        try
        {
            var bookId = await service.AddBook(dto);
            
            return CreatedAtRoute("GetBookById", new { id = bookId }, null);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}