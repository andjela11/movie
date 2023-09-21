using Application.Exceptions;
using Application.Features.GetMovie;
using Application.Interfaces;

using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features;

public class GetMovieQueryHandlerTests
{
    private GetMovieQueryHandler systemUnderTest;
    private Mock<IDataContext> dataContextMock;

    [SetUp]
    public void Setup() => dataContextMock = new Mock<IDataContext>();

    // pattern: AAA
    // A: Arrange
    // A: Act
    // A: Assert

    [Test]
    public void GetMovieQuery_TwoMoviesWithSameIdExists_ShouldThrowMoreThanOneMovieException()
    {
        // Arrange
        const int movieId = 1;
        var movies = new List<Movie>
        {
            new()
            {
                Id = movieId,
                Title = "Rambo"
            },
            new()
            {
                Id = movieId,
                Title = "Rambo 2"
            }, 
        };
        dataContextMock.Setup(x => x.Movies).ReturnsDbSet(movies);

        systemUnderTest = new GetMovieQueryHandler(dataContextMock.Object);
        
        // Act && Assert
        systemUnderTest.Invoking(x => x.Handle(new GetMovieQuery(movieId), new CancellationToken()))
            .Should().ThrowAsync<MoreThanOneMovieException>()
            .WithMessage("This shouldn't be happening");
    }

    [Test]
    // {ActionName}_{TestScenario}_{ShouldHappen}
    public async Task GetMovieQuery_FindById_ShouldReturnMovieAsync()
    {
        // Arrange
        var movies = new List<Movie> { new() { Id = 4, Title = "Rambo" } };

        dataContextMock.Setup(x => x.Movies).ReturnsDbSet(movies);

        systemUnderTest = new GetMovieQueryHandler(this.dataContextMock.Object);

        // Act
        var result = await systemUnderTest.Handle(new GetMovieQuery(4), new CancellationToken());

        // Assert
        result.Should().BeSameAs(movies.First());
    }
}
