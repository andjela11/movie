using Application.Contracts;
using Domain;
using MediatR;

namespace Application.Features.GetMovies;

public record FilterMoviesQuery(PagingParametersDto? PagingParametersDto, MovieFiltersDto? MovieFiltersDto) : IRequest<List<Movie>>;
