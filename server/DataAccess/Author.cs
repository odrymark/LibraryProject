namespace DataAccess;

public class Author
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime createdat { get; set; }
    public ICollection<Book> books { get; set; } =  new List<Book>();
}