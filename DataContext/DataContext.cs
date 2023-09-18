using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}