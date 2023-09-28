using Application.Contracts;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieDto>>
{
    private readonly IDataContext _context;

    public GetAllMoviesQueryHandler(IDataContext context)
    {
        this._context = context;
    }
    
    public async Task<List<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.ToListAsync(cancellationToken);
        if (movies is null)
        {
            throw new Exception("No movies to show");
        }

        return movies.Select(MovieDto.FromMovie).ToList();
    }
}
