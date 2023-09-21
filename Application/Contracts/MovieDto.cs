using Domain;

namespace Application.Contracts;

public record MovieDto(int Id, string Title, List<string> Genre, string Synopsis, int Released)
{
    public static MovieDto FromMovie(Movie movie) 
        => new(movie.Id, movie.Title, movie.Genre, movie.Synopsis, movie.Released);
}
