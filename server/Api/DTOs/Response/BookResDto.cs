namespace Api.DTOs.Response;

public class BookResDto
{
    public int id { get; set; }
    public string title { get; set; }
    public int pages { get; set; }
    public List<String> author { get; set; }
    public string genre { get; set; }
}