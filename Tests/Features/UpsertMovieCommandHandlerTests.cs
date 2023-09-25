using Application.Contracts;
using Application.Exceptions;
using Application.Features.Commands.UpsertMovie;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features;

public class UpsertMovieCommandHandlerTests
{
    private UpsertMovieCommandHandler systemUnderTest;
    private Mock<IDataContext> dataContextMock;

    [SetUp]
    public void Setup() => this.dataContextMock = new Mock<IDataContext>();

    [Test]
    public async Task UpsertMovieCommand_UpdateMovieWithEmptyParameters_ShouldStaySameAsync()
    {
        // Arrange
        const int id = 1;
        var movies = new List<Movie>
        {
            new()
            {
                Id = id,
                Title = "Thor",
                Genre = new List<string> { "Action" },
                Released = 2016,
                Synopsis = "New Thor Movie"
            }
        };

        this.dataContextMock.Setup(x => x.Movies).ReturnsDbSet(movies);

        this.systemUnderTest = new UpsertMovieCommandHandler(this.dataContextMock.Object);

        var upsertMovieDto = ConvertToUpsertMovieDto(movies.First());

        // Act 
        var result = await this.systemUnderTest.Handle(new UpsertMovieCommand(upsertMovieDto), new CancellationToken());

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<MovieDto>();
        result.Id.Should().Be(movies.First().Id);
        result.Title.Should().Be(movies.First().Title);
        result.Genre.Should().Contain(movies.First().Genre);
        result.Synopsis.Should().Be(movies.First().Synopsis);
    }

    [Test]
    public void UpsertMovieCommand_UpdateMovieThatDoesNotExist_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var movies = new List<Movie>
        {
            new()
            {
                Id = 1,
                Title = "Thor",
                Genre = new List<string> { "Action" },
                Released = 2016,
                Synopsis = "New Thor Movie"
            }
        };

        this.dataContextMock.Setup(x => x.Movies).ReturnsDbSet(movies);

        this.systemUnderTest = new UpsertMovieCommandHandler(this.dataContextMock.Object);

        var upsertMovieDto = new UpsertMovieDto(Id: 2, "Thor", new List<string>(), "Description", 2016);

        // Act & Assert
        this.systemUnderTest
            .Invoking(x => x.Handle(new UpsertMovieCommand(upsertMovieDto), new CancellationToken()))
            .Should().ThrowAsync<EntityNotFoundException>();
    }

    private MovieDto ConvertToMovieDto(Movie movie)
    {
        return new MovieDto(movie.Id, movie.Title, movie.Genre, movie.Synopsis, movie.Released);
    }

    private UpsertMovieDto ConvertToUpsertMovieDto(Movie movie)
    {
        return new UpsertMovieDto(movie.Id, movie.Title, movie.Genre, movie.Synopsis, movie.Released);
    }
}
