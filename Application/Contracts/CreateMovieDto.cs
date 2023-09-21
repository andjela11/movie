using Domain;

namespace Application.Contracts;

public record CreateMovieDto(string Title, List<string> Genre, string Synopsis, int Released)
{
    public Movie ToMovie()
    {
        return new Movie { Title = Title, Genre = Genre, Synopsis = Synopsis, Released = Released };
    }
}
