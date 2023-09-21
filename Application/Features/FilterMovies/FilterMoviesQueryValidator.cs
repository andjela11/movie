﻿using FluentValidation;

namespace Application.Features.FilterMovies;

public class FilterMoviesQueryValidator : AbstractValidator<FilterMoviesQuery>
{
    public FilterMoviesQueryValidator()
    {
        When(x => x.MovieFilters is not null, () =>
        {
            When(x => x.MovieFilters!.MinYear > 0, () =>
            {
                RuleFor(x => x.MovieFilters!.MinYear)
                    .InclusiveBetween(1800, DateTime.Now.Year)
                    .WithMessage("Year must be between 1800 and current year");
            });

            When(x => x.MovieFilters!.MaxYear > 0, () =>
            {
                RuleFor(x => x.MovieFilters!.MaxYear).LessThanOrEqualTo(DateTime.Now.Year)
                    .WithMessage("Year must be less than or equal to current year");
            });
        });

        RuleFor(x => x.PageNumber).GreaterThan(0)
            .WithMessage("Page number must be greater than 0");
        RuleFor(x => x.PageSize).GreaterThan(0)
            .WithMessage("Page size must be greater than 0");
    }
}
