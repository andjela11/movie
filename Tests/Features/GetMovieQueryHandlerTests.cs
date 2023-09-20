using Application.Features.GetMovie;
using Application.Interfaces;

using Domain;

using Microsoft.EntityFrameworkCore;

using Moq;

namespace Tests.Features;

public class GetMovieQueryHandlerTests
{
    private GetMovieQueryHandler systemUnderTest;
    private Mock<IDataContext> dataContextMock;
    private Mock<DbSet<Movie>> moviesMock;

    [SetUp]
    public void Setup()
    {
        dataContextMock = new Mock<IDataContext>();
        moviesMock = new Mock<DbSet<Movie>>();
    }

    // pattern: AAA
    // A: Arrange
    // A: Act
    // A: Assert

    // [Test]
    // public async Task<Movie> GetMovie_TwoMoviesWithSameIdExists_ShouldThrowInvalidOperationExceptionAsync()
    // {
    //     // Arrange
    //     var movies = new List<Movie>
    //     {
    //         new()
    //         {
    //             Id = 1,
    //             Title = "Rambo"
    //         },
    //         new()
    //         {
    //             Id = 1,
    //             Title = "Rambo 2"
    //         }, 
    //     };
    //
    //     moviesMock.As<IQueryable<Movie>>().Setup(x => x.Pr);
    //     dataContextMock.Object.Movies = moviesMock;
    //     
    //     await dataContextMock.Movies.AddRange(movies)
    // }
}
