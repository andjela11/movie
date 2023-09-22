using Domain;

using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IDataContext
{
    public DbSet<Movie> Movies { get; set; }

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken token);
    Task<int> SaveChangesAsync(bool test, CancellationToken token);
}
