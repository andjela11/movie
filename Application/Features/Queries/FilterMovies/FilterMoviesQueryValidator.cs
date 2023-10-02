using FluentValidation;

namespace Application.Features.Queries.FilterMovies;

public class FilterMoviesQueryValidator : AbstractValidator<FilterMoviesQuery>
{
    public FilterMoviesQueryValidator()
    {
        
        RuleFor(x => x.PageNumber).GreaterThan(0)
            .WithMessage("Page number must be greater than 0");
        RuleFor(x => x.PageSize).GreaterThan(0)
            .WithMessage("Page size must be greater than 0");
        
        /*
        When(x => x.MovieFilter is not null, () =>
        {
            When(x => x.MovieFilter!.MinYear > 0, () =>
            {
                RuleFor(x => x.MovieFilter!.MinYear)
                    .InclusiveBetween(1800, DateTime.Now.Year)
                    .WithMessage("Year must be between 1800 and current year");
            });

            When(x => x.MovieFilter!.MaxYear > 0, () =>
            {
                RuleFor(x => x.MovieFilter!.MaxYear).LessThanOrEqualTo(DateTime.Now.Year)
                    .WithMessage("Year must be less than or equal to current year");
            });

            When(x => x.MovieFilter!.MinYear < 0, () =>
            {
                RuleFor(x => x.MovieFilter!.MinYear)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Year can not be less than 0");
            });

            When(x => x.MovieFilter!.MaxYear < 0, () =>
            {
                RuleFor(x => x.MovieFilter!.MaxYear)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Year can not be less than 0");
            });
        });
        */

    }
}
