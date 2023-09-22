using FluentValidation;

namespace Application.Features.Queries.GetMovie;

public class GetMovieQueryValidator : AbstractValidator<GetMovieQuery>
{
    public GetMovieQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("Id can not be less than or equal to 0");
    }
}
