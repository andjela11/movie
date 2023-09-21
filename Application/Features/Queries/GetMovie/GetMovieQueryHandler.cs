using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.GetMovie;

public sealed class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, Movie?>
{
    private readonly IDataContext _context;

    public GetMovieQueryHandler(IDataContext context)
    {
        this._context = context;
    }

    public async Task<Movie?> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        Movie? movie;
        try
        {
            movie = await this._context.Movies.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return movie;
        }
        catch (InvalidOperationException e)
        {
            throw new MoreThanOneMovieException("This shouldn't be happening", e);
        }
    }
}
