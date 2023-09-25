using Application.Features.Commands.DeleteMovie;
using FluentAssertions;

namespace Tests.Validators;

public class DeleteMovieCommandValidatorTests
{
    private DeleteMovieCommandValidator? _validator;

    [SetUp]
    public void Setup()
    {
        this._validator = new DeleteMovieCommandValidator();
    }

    [Test]
    public void DeleteMovieCommandValidator_ValidPayload_ShouldBeValid()
    {
        this._validator?.Validate(GetValidPayload()).IsValid.Should().BeTrue();
    }

    [Test]
    public void DeleteMovieCommandValidator_IdIsZero_ShouldBeInvalid()
    {
        var deleteMovieCommand = GetValidPayload() with { Id = 0 };
        this._validator?.Validate(deleteMovieCommand).IsValid.Should().BeFalse();
    }

    [Test]
    public void DeleteMovieCommandValidator_IdIsNegative_ShouldBeInvalid()
    {
        var deleteMovieCommand = GetValidPayload() with { Id = -5 };
        this._validator?.Validate(deleteMovieCommand).IsValid.Should().BeFalse();
    }

    private DeleteMovieCommand GetValidPayload()
    {
        return new DeleteMovieCommand(4);
    }
}
