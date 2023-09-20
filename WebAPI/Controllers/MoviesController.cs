using System.Net;
using Application;
using Application.Contracts;
using Application.Features.GetMovie;
using Application.Features.GetMovies;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Returns movie object based on a specific ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see cref="Movie"/></returns>
    [HttpGet("{id:int}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Movie))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Movie couldn't be found with given id")]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected event occurred")]
    public async Task<ActionResult<Movie>> GetMovieAsync(int id)
    {
        var getMovieQuery = new GetMovieQuery(id);
        var movie = await _mediator.Send(getMovieQuery);

        if (movie is not null)
        {
            return Ok(movie);
        }

        return NotFound();
    }

    [HttpPost("get-movies")]
    public async Task<ActionResult<List<Movie>>> GetMovies(
        [FromQuery] PagingParametersDto pagingParametersDto,
        [FromBody] MovieFiltersDto movieFiltersDto)
    {
        var getMoviesQuery = new FilterMoviesQuery(pagingParametersDto, movieFiltersDto);
        var movies = await this._mediator.Send(getMoviesQuery);

        if (movies.Count == 0)
        {
            return NoContent();
        }
        
        return Ok(movies);
        
    }
}
