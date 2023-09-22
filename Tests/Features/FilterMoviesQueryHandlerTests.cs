using Application.Contracts;
using Application.Features.Commands.DeleteMovie;
using Application.Features.Queries.FilterMovies;
using Application.Interfaces;
using Domain;
using FluentAssertions;
using FluentValidation;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Features;

public class FilterMoviesQueryHandlerTests
{
    private FilterMoviesQueryHandler? _systemUnderTest;
    private Mock<IDataContext>? _dataContextMock;

    [SetUp]
    public void Setup() => this._dataContextMock = new Mock<IDataContext>();

    // [Test]
    // public async Task FilterMoviesQuery_PageNumberEqualsZero_ShouldThrowValidationExceptionAsync()
    // {
        // Arrange 
        // var movies = new List<Movie> { new() { Id = 3, Title = "Rambo" } }.AsQueryable();
        //
        // this._dataContextMock?.Setup(x => x.Movies).ReturnsDbSet(movies);
        //
        // this._systemUnderTest = new FilterMoviesQueryHandler(this._dataContextMock?.Object!);
        // this._dataContextMock.Object.Movies.AsAsyncEnumerable();
        //
        // // Act & Assert
        // var result = await this._systemUnderTest.Handle(new FilterMoviesQuery(1, 1, new MovieFilterDto(1900, 2100)),
        //     It.IsAny<CancellationToken>());
        // result.Count.Should().Be(1);
        // this._systemUnderTest.Invoking(x =>
        //         x.Handle(
        //             new FilterMoviesQuery(2, 0, It.IsAny<MovieFilterDto>()),
        //             new CancellationToken()))
        //     .Should().ThrowAsync<ValidationException>();
   // }
}
