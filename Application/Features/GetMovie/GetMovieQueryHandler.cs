using Application.Interfaces;

using Domain;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Features.GetMovie;

public sealed class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, Movie?>
{
    private readonly IDataContext _context;

    public GetMovieQueryHandler(IDataContext context)
    {
        _context = context;
    }

    public Task<Movie?> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = _context.Movies.SingleOrDefaultAsync(x => x.Id == request.Id,
            cancellationToken: cancellationToken);
        return movie;
    }
}
