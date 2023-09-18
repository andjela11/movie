namespace Domain;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string[] Genre { get; set; }
    public string[] ImdbURL { get; set; }
    public float ImdbRating { get; set; }
    public string Synopsis { get; set; }
    public int Released { get; set; }
}