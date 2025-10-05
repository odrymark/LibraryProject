using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Get;

public class BookGetDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "The length of the title must be between 1 and 50.")]
    public string title { get; set; }
    
    [Required(ErrorMessage = "Pages is required.")]
    [Range(1, 10000, ErrorMessage = "The number of pages must be between 1 and 10000")]
    public int pages { get; set; }
    
    [Required(ErrorMessage = "Author is required.")]
    [MinLength(1, ErrorMessage = "At least one author must be provided.")]
    public List<string> author { get; set; }
    
    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "The length of the genre must be between 1 and 30.")]
    public string genre { get; set; }
}