using FluentValidation;

namespace Application.Features.Commands.DeleteMovie;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
