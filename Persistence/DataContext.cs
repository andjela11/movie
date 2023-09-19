using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain;
using Bogus;

namespace Persistence;

public class DataContext : DbContext//, IDataContext
{
    public DbSet<Movie> Movies { get; set; }

    public DataContext()
    { }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {  }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;User ID=root;Password=root123;Database=movies");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(m =>
        {
            m.HasKey(e => e.Id);
            m.Property(x => x.ImdbURL)
                .HasConversion(
                    urls => string.Join(',', urls),
                    urls => urls.Split(',', StringSplitOptions.None).ToList()!
                    );
            m.Property(x => x.Genre)
                .HasConversion(
                    urls => string.Join(',', urls),
                    urls => urls.Split(',',StringSplitOptions.None).ToList()
                );
        });

        var fakeMovies = new List<Movie>();
        for (var i = 0; i < 100; i++)
        {
            var fakeMovie = new Faker<Movie>()
                .RuleFor(x => x.Id, i+1)
                .RuleFor(x => x.Title, f => f.Name.FirstName())
                .RuleFor(x => x.Synopsis, f => f.Lorem.Paragraph())
                .RuleFor(x => x.ImdbURL, f => f.Make(3, () => f.Address.FullAddress()))
                .RuleFor(x => x.Genre, f => f.Make(3, () => f.Music.Genre()))
                .RuleFor(x => x.ImdbRating, f => 7.4f)
                .RuleFor(x => x.Released, f => f.Date.Past().Year);
            fakeMovies.Add(fakeMovie);
        }
        
        modelBuilder.Entity<Movie>().HasData(fakeMovies);
    }
}