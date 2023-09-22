using Application.Contracts;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.UpsertMovie;

public sealed class UpsertMovieCommandHandler : IRequestHandler<UpsertMovieCommand, MovieDto>
{
    private readonly IDataContext _context;

    public UpsertMovieCommandHandler(IDataContext context)
    {
        this._context = context;
    }

    public async Task<MovieDto> Handle(UpsertMovieCommand request, CancellationToken cancellationToken)
    {
        Movie? movie;
        if (request.MovieUpsert.Id is not null)
        {
            movie = await this._context.Movies.SingleOrDefaultAsync(x => x.Id == request.MovieUpsert.Id,
                cancellationToken);

            if (movie is null)
            {
                throw new EntityNotFoundException();
            }

            movie = request.MovieUpsert.ToUpdateMovie(movie);
            this._context.Movies.Update(movie);
        }
        else
        {
            var movieToCreate = request.MovieUpsert.ToMovie();
            this._context.Movies.Add(movieToCreate);
            movie = movieToCreate;
        }

        await this._context.SaveChangesAsync(cancellationToken);

        return MovieDto.FromMovie(movie);
    }
}
