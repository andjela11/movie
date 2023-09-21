using FluentValidation;

namespace Application.Features.GetMovie;

public class GetMovieQueryValidation : AbstractValidator<GetMovieQuery>
{
    public GetMovieQueryValidation()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("Id can not be less than 0");
    }
}
