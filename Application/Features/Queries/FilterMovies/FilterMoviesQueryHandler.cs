using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.FilterMovies;

public sealed class FilterMoviesQueryHandler : IRequestHandler<FilterMoviesQuery, List<Movie>>
{
    private readonly IDataContext _context;

    public FilterMoviesQueryHandler(IDataContext context)
    {
        this._context = context;
    }

    public async Task<List<Movie>> Handle(FilterMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = this._context.Movies.AsQueryable();
        if (request.MovieFilter!.MinYear != 0)
        {
            movies = movies.Where(x => x.Released >= request.MovieFilter.MinYear);
        }

        if (request.MovieFilter.MaxYear != 0)
        {
            movies = movies.Where(x => x.Released <= request.MovieFilter.MaxYear);
        }

        return await movies
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
    }
}
