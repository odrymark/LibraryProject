namespace DataAccess;

public class Book
{
    public int id { get; set; }
    public string title { get; set; }
    public int pages { get; set; }
    public int genreid { get; set; }
    public DateTime createdat { get; set; }
    public ICollection<Author> authors { get; set; } =  new List<Author>();
}