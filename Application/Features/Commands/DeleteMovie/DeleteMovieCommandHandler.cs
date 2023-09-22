using Application.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Commands.DeleteMovie;

public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IDataContext _context;

    public DeleteMovieCommandHandler(IDataContext context)
    {
        this._context = context;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FindAsync(request.Id);

        if (movie is null)
        {
            throw new EntityNotFoundException("Movie not found");
        }

        this._context.Movies.Remove(movie);
        await this._context.SaveChangesAsync(cancellationToken);
    }
}
