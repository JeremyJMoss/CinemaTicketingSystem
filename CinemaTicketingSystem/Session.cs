namespace CinemaTicketingSystem;

public class Session
{
    public Session(DateTime startTime, Movie movie, Cinema cinema)
    {
        StartTime = startTime;
        Movie = movie;
        Cinema = cinema;
    }
    
    public Movie Movie { get; set; }

    public Cinema Cinema { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime => StartTime.AddMinutes(Movie.Duration + 20); 
}

    
    
    
    