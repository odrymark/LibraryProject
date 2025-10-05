using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(x => x.id);
        modelBuilder.Entity<Genre>().HasKey(x => x.id);
        modelBuilder.Entity<Author>().HasKey(x => x.id);

        modelBuilder.Entity<Book>()
            .HasOne<Genre>()
            .WithMany(g => g.books)
            .HasForeignKey(b => b.genreid);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.authors)
            .WithMany(a => a.books)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorBookJunction",
                j => j.HasOne<Author>().WithMany().HasForeignKey("authorid"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("bookid")
            );
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
}