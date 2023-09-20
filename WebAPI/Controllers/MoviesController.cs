using System.Net;
using Application.Features.GetMovie;
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
}
