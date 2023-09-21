using Application.Contracts;
using Domain;
using MediatR;

namespace Application.Features.FilterMovies;

public record FilterMoviesQuery(int PageSize, int PageNumber, MovieFilter? MovieFilters) : IRequest<List<Movie>>;
