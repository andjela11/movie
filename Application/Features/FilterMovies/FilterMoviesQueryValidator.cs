using FluentValidation;

namespace Application.Features.FilterMovies;

public class FilterMoviesQueryValidator : AbstractValidator<FilterMoviesQuery>
{
    public FilterMoviesQueryValidator()
    {
        When(x => x.MovieFiltersDto is not null, () =>
        {
            RuleFor(x => x.MovieFiltersDto!.MaxYear).LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Year must be less than current year");
            RuleFor(x => x.MovieFiltersDto!.MaxYear).GreaterThanOrEqualTo(0)
                .WithMessage("Year must be greater than 0");
            RuleFor(x => x.MovieFiltersDto!.MinYear).GreaterThanOrEqualTo(0)
                .WithMessage("Year must be greater than 0");
        });

        RuleFor(x => x.PageNumber).GreaterThan(0)
            .WithMessage("Page number must be greater than 0");
        RuleFor(x => x.PageSize).GreaterThan(0)
            .WithMessage("Page size must be greater than 0");
        ;
    }
}
