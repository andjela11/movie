using FluentValidation;

namespace Application.Features.Commands.UpsertMovie;

public class UpsertMovieCommandValidator : AbstractValidator<UpsertMovieCommand>
{
    public UpsertMovieCommandValidator()
    {
        RuleFor(x => x.MovieUpsert)
            .NotNull()
            .WithMessage("Movie must not be null");

        When(x => x.MovieUpsert.Id is not null, () =>
        {
            RuleFor(x => x.MovieUpsert.Id).GreaterThan(0);

            When(x => x.MovieUpsert.Released != 0, () =>
            {
                RuleFor(x => x.MovieUpsert.Released)
                    .InclusiveBetween(1800, DateTime.Now.Year)
                    .WithMessage("Year must be between 1800 and current year");
            });
        });

        When(x => x.MovieUpsert.Id is null, () =>
        {
            RuleFor(x => x.MovieUpsert.Released)
                .InclusiveBetween(1800, DateTime.Now.Year)
                .WithMessage("Year must be between 1800 and current year");

            RuleFor(x => x.MovieUpsert.Title)
                .NotEmpty()
                .WithMessage("Title must be provided");

            RuleFor(x => x.MovieUpsert.Genre)
                .NotEmpty()
                .WithMessage("At least one genre must be provided");

            RuleFor(x => x.MovieUpsert.Synopsis)
                .NotEmpty()
                .WithMessage("Provide description for the movie");
        });
    }
}
