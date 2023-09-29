using Application.Exceptions;
using Application.Features.Queries.GetAllMovies;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features;

public class GetAllMoviesQueryHandlerTests
{
    private GetAllMoviesQueryHandler _systemUnderTest;
    private Mock<IDataContext> _mockContext;

    [SetUp]
    public void Setup() => _mockContext = new Mock<IDataContext>();

    [Test]
    public async Task Handle_GetAllMovies_ShouldReturnAllMoviesAsync()
    {
        // Arrange 
        var movies = new List<Movie>
        {
            new()
            {
                Id = 1,
                Title = "Thor",
                Genre = new List<string> { "action" },
                ImdbRating = 9,
                ImdbURL = new List<string>(),
                Released = 2020,
                Synopsis = "description"
            },
            new()
            {
                Id = 1,
                Title = "Thor",
                Genre = new List<string> { "action" },
                ImdbRating = 9,
                ImdbURL = new List<string>()!,
                Released = 2020,
                Synopsis = "description"
            },
        };

        _mockContext.Setup(x => x.Movies).ReturnsDbSet(movies);

        _systemUnderTest = new GetAllMoviesQueryHandler(_mockContext.Object);
        
        // Act
        var result = await this._systemUnderTest.Handle(new GetAllMoviesQuery(), new CancellationToken());
        
        // Assert
        result.Count.Should().Be(movies.Count);
    }
    
    [Test]
    public void Handle_GetEmptyList_ShouldThrowException()
    {
        // Arrange 
        var movies = new List<Movie>();

        _mockContext.Setup(x => x.Movies).ReturnsDbSet(movies);

        _systemUnderTest = new GetAllMoviesQueryHandler(_mockContext.Object);
        
        // Act & Assert
        this._systemUnderTest.Invoking(x =>
                x.Handle(new GetAllMoviesQuery(), new CancellationToken()))
            .Should().ThrowAsync<EntityNotFoundException>()
            .WithMessage("No movies to show");
    }
}
