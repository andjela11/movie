namespace Application.Exceptions;

public sealed class MoreThanOneMovieException : Exception
{
    public MoreThanOneMovieException()
    { }

    public MoreThanOneMovieException(string message)
        : base(message)
    { }

    public MoreThanOneMovieException(string message, Exception inner)
        : base(message, inner)
    { }
}
