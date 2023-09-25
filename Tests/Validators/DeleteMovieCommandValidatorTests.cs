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
        // Arrange
        var deleteMovieCommand = GetValidPayload();
        
        // Act & Assert
        this._validator?.Validate(deleteMovieCommand).IsValid.Should().BeTrue();
    }

    [Test]
    public void DeleteMovieCommandValidator_IdIsZero_ShouldBeInvalid()
    {
        // Arrange
        var deleteMovieCommand = GetValidPayload() with { Id = 0 };
        
        // Act & Assert
        this._validator?.Validate(deleteMovieCommand).IsValid.Should().BeFalse();
    }

    [Test]
    public void DeleteMovieCommandValidator_IdIsNegative_ShouldBeInvalid()
    {
        // Arrange
        var deleteMovieCommand = GetValidPayload() with { Id = -5 };
        
        // Act && Assert
        this._validator?.Validate(deleteMovieCommand).IsValid.Should().BeFalse();
    }

    private DeleteMovieCommand GetValidPayload()
    {
        return new DeleteMovieCommand(4);
    }
}
