using System.Net;
using Application.Exceptions;
using Application.Features.Commands.DeleteMovie;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features;

public class DeleteMovieCommandHandlerTests
{
    private DeleteMovieCommandHandler? _systemUnderTest;
    private Mock<IDataContext>? _dataContextMock;

    [SetUp]
    public void SetUp() => this._dataContextMock = new Mock<IDataContext>();

    [Test]
    public void DeleteMovieCommand_MovieDoesNotExist_ShouldThrowEntityNotFoundException()
    {
        // Arrange 
        var movies = new List<Movie>();

        this._dataContextMock?.Setup(x => x.Movies).ReturnsDbSet(movies);

        this._systemUnderTest = new DeleteMovieCommandHandler(this._dataContextMock?.Object!);

        // Act & Assert
        this._systemUnderTest.Invoking(x =>
                x.Handle(new DeleteMovieCommand(-1), new CancellationToken()))
            .Should().ThrowAsync<EntityNotFoundException>()
            .WithMessage("This shouldn't be happening");
    }

    [Test]
    public void DeleteMovieCommand_DeleteMovieWithGivenId_ShouldDeleteMovie()
    {
        // Arrange 
        var movies = new List<Movie> { new() { Id = 3, Title = "Rambo" } };

        this._dataContextMock?.Setup(x => x.Movies).ReturnsDbSet(movies);

        this._systemUnderTest = new DeleteMovieCommandHandler(this._dataContextMock?.Object!);

        // Act & Assert
        this._systemUnderTest.Invoking(x =>
                x.Handle(new DeleteMovieCommand(3), new CancellationToken()))
            .Should().NotThrowAsync();
        this._dataContextMock?.Verify(dataContext => dataContext.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Once());
    }
    
    [Test]
    public void DeleteMovieCommand_TwoMoviesWithSameId_ShouldThrowInvalidOperationException()
    {
        // Arrange 
        var movies = new List<Movie> { new() { Id = 3, Title = "Rambo" },  new() { Id = 3, Title = "Rambo 1" } };

        this._dataContextMock?.Setup(x => x.Movies).ReturnsDbSet(movies);

        this._systemUnderTest = new DeleteMovieCommandHandler(this._dataContextMock?.Object!);

        // Act & Assert
        this._systemUnderTest.Invoking(x =>
                x.Handle(new DeleteMovieCommand(3), new CancellationToken()))
            .Should().ThrowAsync<InvalidOperationException>();
        this._dataContextMock?.Verify(dataContext => dataContext.SaveChangesAsync(It.IsAny<CancellationToken>()),
            Times.Exactly(0));
    }
}
