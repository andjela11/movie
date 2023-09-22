using MediatR;

namespace Application.Features.Commands.DeleteMovie;

public record DeleteMovieCommand(int Id) : IRequest<Unit>;
