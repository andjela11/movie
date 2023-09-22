using Application.Contracts;
using MediatR;

namespace Application.Features.Commands.UpsertMovie;

public record UpsertMovieCommand(UpsertMovieDto MovieUpsert) : IRequest<MovieDto>;

