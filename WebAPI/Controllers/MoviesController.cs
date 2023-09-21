using System.Net;
using Application.Contracts;
using Application.Features.Commands.CreateMovie;
using Application.Features.Queries.FilterMovies;
using Application.Features.Queries.GetMovie;
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

    /// <summary>
    /// Returns a paginated movies based on passed filters for released years
    /// </summary>
    /// <param name="movieFilter">Filter movies by year range</param>
    /// <param name="pageSize">Number of movies per page</param>
    /// <param name="pageNumber">Pages number</param>
    /// <returns>List of <see cref="Movie"/></returns>
    [HttpPost("filter")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Movie))]
    [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, Description = "Unsuccessful validation")]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected event occurred")]
    public async Task<ActionResult<List<Movie>>> GetMoviesAsync(
        [FromBody] MovieFilterDto movieFilter,
        [FromQuery] int pageSize = 50,
        [FromQuery] int pageNumber = 1)
    {
        var getMoviesQuery = new FilterMoviesQuery(PageSize: pageSize, PageNumber: pageNumber, movieFilter);
        var movies = await this._mediator.Send(getMoviesQuery);

        return Ok(movies);
    }


    /// <summary>
    /// Creates movie based on given parameters
    /// </summary>
    /// <param name="movieCreate">Parameters for movie object</param>
    /// <returns><see cref="MovieDto"/></returns>
    [HttpPost("create")]
    [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(Movie))]
    [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, Description = "Unsuccessful validation")]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected event occurred")]
    public async Task<ActionResult> CreateMovieAsync([FromBody] CreateMovieDto movieCreate)
    {
        var createMovieCommand = new CreateMovieCommand(movieCreate);
        var movieDto = await this._mediator.Send(createMovieCommand);

        return Created($"movies/{movieDto.Id}", movieDto);
    }
}
