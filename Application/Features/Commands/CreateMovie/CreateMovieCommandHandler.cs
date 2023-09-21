using Application.Contracts;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Commands.CreateMovie;

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IDataContext _context;

    public CreateMovieCommandHandler(IDataContext context)
    {
        this._context = context;
    }
    
    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = request.MovieCreate.ToMovie();

        this._context.Movies.Add(movie);
        await this._context.SaveChangesAsync(cancellationToken);
        
        return MovieDto.FromMovie(movie);
    }
}
