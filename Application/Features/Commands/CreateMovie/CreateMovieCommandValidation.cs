using FluentValidation;

namespace Application.Features.Commands.CreateMovie;

public class CreateMovieCommandValidation : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidation()
    {
        RuleFor(x => x.MovieCreate)
            .NotNull()
            .WithMessage("Movie must not be null");
        
        When(x => x.MovieCreate is not null, () =>
        {
            RuleFor(x => x.MovieCreate.Released)
                .InclusiveBetween(1800, DateTime.Now.Year)
                .WithMessage("Year must be between 1800 and current year");

            RuleFor(x => x.MovieCreate.Title)
                .NotEmpty()
                .WithMessage("Title must be provided");

            RuleFor(x => x.MovieCreate.Genre)
                .NotEmpty()
                .WithMessage("At least one genre must be provided");
            
            RuleFor(x => x.MovieCreate.Synopsis)    
                .NotEmpty()
                .WithMessage("Provide description for the movie");
        });
    }
}
