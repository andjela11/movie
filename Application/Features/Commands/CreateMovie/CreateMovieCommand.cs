using Application.Contracts;
using MediatR;

namespace Application.Features.Commands.CreateMovie;

public record CreateMovieCommand(CreateMovieDto MovieCreate) : IRequest<MovieDto>;

