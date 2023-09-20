using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GetMovies;

public class FilterMoviesQueryHandler : IRequestHandler<FilterMoviesQuery, List<Movie>>
{
    private readonly IDataContext _context;

    public FilterMoviesQueryHandler(IDataContext context)
    {
        this._context = context;
    }

    public async Task<List<Movie>> Handle(FilterMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = this._context.Movies.AsQueryable();
        if (request.MovieFiltersDto.MinYear != 0)
        {
            movies = movies.Where(x => x.Released >= request.MovieFiltersDto.MinYear);
        }
        
        if (request.MovieFiltersDto.MaxYear != 0)
        {
            movies = movies.Where(x => x.Released <= request.MovieFiltersDto.MaxYear);
        }

        return await movies
            .Skip((request.PagingParametersDto.PageNumber - 1) * request.PagingParametersDto.PageSize)
            .Take(request.PagingParametersDto.PageSize)
            .ToListAsync(cancellationToken);
        // return movies;
    }
}
