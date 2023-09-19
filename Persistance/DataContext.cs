using Microsoft.EntityFrameworkCore;
using Domain;
using System.Net.Http.Headers;
using System.Text.Json;
using Bogus;

namespace Persistance;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }

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

        var fakeMovies = new Faker<Movie>()
            .RuleFor(x => x.Id, x => x.Random.Number(1, 100))
            .RuleFor(x => x.Title, f => f.Name.ToString())
            .RuleFor(x => x.Synopsis, f => f.Lorem.ToString())
            .RuleFor(x => x.ImdbURL, f => f.Make(3, () => f.Address.ToString()))
            .RuleFor(x => x.Genre, f => f.Make(3, () => f.Music.ToString()))
            .RuleFor(x => x.ImdbRating, f => 7.4f)
            .RuleFor(x => x.Released, f => f.Date.Past().Year);

        modelBuilder.Entity<Movie>().HasData(fakeMovies);
    }
}