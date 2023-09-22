using FluentValidation;

namespace Application.Features.Commands.DeleteMovie;

public class DeleteMovieCommandValidation : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidation()
    {
        RuleFor(x => x.Id).NotNull();
    }
}
