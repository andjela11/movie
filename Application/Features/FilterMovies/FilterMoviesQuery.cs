using Application.Contracts;
using Domain;
using MediatR;

namespace Application.Features.FilterMovies;

public record FilterMoviesQuery(int PageSize, int PageNumber, MovieFilters? MovieFiltersDto) : IRequest<List<Movie>>;
