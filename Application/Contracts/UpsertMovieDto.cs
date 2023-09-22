using Domain;

namespace Application.Contracts;

public record UpsertMovieDto(int? Id, string? Title, List<string>? Genre, string? Synopsis, int? Released)
{
    public Movie ToCreateMovie()
        => new() { Title = Title, Genre = Genre, Synopsis = Synopsis, Released = Released };

    public Movie ToUpdateMovie(Movie movie)
    {
        movie.Released = Released ?? movie.Released;
        movie.Title = string.IsNullOrWhiteSpace(Title) ? movie.Title : Title;
        movie.Synopsis = string.IsNullOrWhiteSpace(Synopsis) ? movie.Synopsis : Synopsis;
        movie.Genre = Genre is null || Genre?.Count == 0
            ? movie.Genre
            : Genre;

        return movie;
    }
}
