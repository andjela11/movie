using Domain;

using MediatR;

namespace Application.Features.GetMovie;

public record GetMovieQuery(int Id) : IRequest<Movie?>;
