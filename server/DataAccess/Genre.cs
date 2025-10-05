namespace DataAccess;

public class Genre
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime createdat { get; set; }
    public ICollection<Book> books { get; set; } =  new List<Book>();
}