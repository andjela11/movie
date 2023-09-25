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
        this._validator.Validate(GetValidPayload()).IsValid.Should().BeTrue();
    }

    [Test]
    public void GetMovieQueryValidator_IdIsZero_ShouldBeInvalid()
    {
        var getMovieQuery = GetValidPayload() with { Id = 0 };
        this._validator.Validate(getMovieQuery).IsValid.Should().BeFalse();
    }

    [Test]
    public void GetMovieQueryValidator_IdIsNegative_ShouldBeInvalid()
    {
        var getMovieQuery = GetValidPayload() with { Id = -2 };
        this._validator.Validate(getMovieQuery).IsValid.Should().BeFalse();
    }

    private GetMovieQuery GetValidPayload()
    {
        return new GetMovieQuery(3);
    }
}
