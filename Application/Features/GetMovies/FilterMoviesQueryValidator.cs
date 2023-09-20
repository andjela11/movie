using FluentValidation;

namespace Application.Features.GetMovies;

public class FilterMoviesQueryValidator : AbstractValidator<FilterMoviesQuery>
{
    public FilterMoviesQueryValidator()
    {
        When(x => x.MovieFiltersDto is not null, () =>
        {
            RuleFor(x => x.MovieFiltersDto!.MaxYear <= DateTime.Now.Year);
            RuleFor(x => x.MovieFiltersDto!.MaxYear < 0);
            RuleFor(x => x.MovieFiltersDto!.MinYear < 0);
        });
        
        When(x => x.PagingParametersDto is not null, () =>
        {
            RuleFor(x => x.PagingParametersDto!.PageNumber <= 0);
            RuleFor(x => x.PagingParametersDto!.PageSize <= 0);
        });
        
    }
}
