using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly DataContext _context;

    public MoviesController()//Persistance.Persistance context)
    {
        //_context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Movie>> GetMovies()
    {
        try
        {
            return Ok(await _context.Movies.ToListAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}