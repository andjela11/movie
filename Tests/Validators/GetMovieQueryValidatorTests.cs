using Application.Features.Commands.DeleteMovie;
using Application.Features.Queries.GetMovie;
using FluentAssertions;

namespace Tests.Validators;

public class GetMovieQueryValidatorTests
{
    private GetMovieQueryValidator _validator;

    [SetUp]
    public void Setup()
    {
        this._validator = new GetMovieQueryValidator();
    }

    [Test]
    public void GetMovieQueryValidator_ValidPayload_ShouldBeValid()
    {
        // Arrange
        GetMovieQuery getMovieQuery = GetValidPayload();
        
        // Act
        var result = this._validator.Validate(getMovieQuery);
        
        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Test]
    public void GetMovieQueryValidator_IdIsZero_ShouldBeInvalid()
    {
        // Arrange
        var getMovieQuery = GetValidPayload() with { Id = 0 };
        
        // Act
        var resulst = this._validator.Validate(getMovieQuery);
        
        // Assert
        resulst.IsValid.Should().BeFalse();
    }

    [Test]
    public void GetMovieQueryValidator_IdIsNegative_ShouldBeInvalid()
    {
        // Arrange
        var getMovieQuery = GetValidPayload() with { Id = -2 };

        // Act
        var result = this._validator.Validate(getMovieQuery);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }

    private GetMovieQuery GetValidPayload()
    {
        return new GetMovieQuery(3);
    }
}
