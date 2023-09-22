using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Commands.DeleteMovie;

public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly IDataContext _context;

    public DeleteMovieCommandHandler(IDataContext context)
    {
        this._context = context;
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == request.Id, 
            cancellationToken: cancellationToken);

        if (movie is null)
        {
            throw new EntityNotFoundException($"Movie with the id:{request.Id} was not found");
        }

        this._context.Movies.Remove(movie);
        await this._context.SaveChangesAsync(cancellationToken);

        return default;
    }
}
