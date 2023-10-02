using Application.Contracts;
using Domain;
using MediatR;

namespace Application.Features.Queries.FilterMovies;

public record FilterMoviesQuery(int PageSize, int PageNumber /*MovieFilterDto? MovieFilter*/) : IRequest<List<Movie>>;
