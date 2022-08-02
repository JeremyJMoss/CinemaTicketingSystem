namespace CinemaTicketingSystem;

public class Movie
{
    public Movie(string title, int duration, string rating)
    {
        Title = title;
        Duration = duration;
        Rating = rating;
    }
    
    public string Title { get; set; }
    
    public int Duration { get; set; }

    public string Rating { get; set; }
}