using FluentValidation;

namespace Application.Features.Commands.DeleteMovie;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Id must be greater than 0");
    }
}
