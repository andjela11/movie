namespace Application.Contracts;

public record MovieFilter
{
    public int MinYear { get; set; }
    public int MaxYear { get; set; }
}
