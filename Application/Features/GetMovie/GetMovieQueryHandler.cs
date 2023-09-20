using Application.Exceptions;
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

    public async Task<Movie?> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException();
        Movie? movie;
        try
        {
            movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
        catch (InvalidOperationException e)
        {
            throw new MoreThanOneMovieException("This shouldn't be happening", e);
        }
        return movie;
    }
}
