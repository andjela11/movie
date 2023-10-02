using Application.Interfaces;

using Bogus;

using Domain;

using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext, IDataContext
{
    public DbSet<Movie> Movies { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

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
                    urls => urls.Split(',', StringSplitOptions.None).ToList()
                );
        });

        var fakeMovies = new List<Movie>();
        for (var i = 0; i < 20; i++)
        {
            var fakeMovie = new Faker<Movie>()
                .RuleFor(x => x.Id, i + 1)
                .RuleFor(x => x.Title, f => f.Name.FirstName())
                .RuleFor(x => x.Synopsis, f => f.Lorem.Paragraph())
                .RuleFor(x => x.ImdbURL, f => f.Make(3, () => f.Address.FullAddress()))
                .RuleFor(x => x.Genre, f => f.Make(3, () => f.Music.Genre()))
                .RuleFor(x => x.ImdbRating, f => 7.4f)
                .RuleFor(x => x.Released, f => f.Date.Past().Year)
                .RuleFor(x => x.CreatedAt, f => f.Date.Past())
                .RuleFor(x => x.UpdatedAt, f => DateTime.UtcNow);
            fakeMovies.Add(fakeMovie);
        }

        modelBuilder.Entity<Movie>().HasData(fakeMovies);
    }
    
    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entry in entities)
        {
            var dateNow = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedAt = dateNow;
            }
            ((BaseEntity)entry.Entity).UpdatedAt = dateNow;
        }
    }
}
