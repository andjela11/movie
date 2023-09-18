namespace Persistence;

public class DataContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DataContext(DbContextOptions options) : base(options)
    {
    }
}