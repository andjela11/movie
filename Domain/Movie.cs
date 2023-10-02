namespace Domain;

public class Movie : BaseEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public List<string>? Genre { get; set; }
    public List<string?>? ImdbURL { get; set; }
    public float ImdbRating { get; set; }
    public string? Synopsis { get; set; }
    public int? Released { get; set; }
}
