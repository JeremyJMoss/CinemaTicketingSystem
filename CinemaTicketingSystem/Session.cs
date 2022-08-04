namespace CinemaTicketingSystem;

public class Session
{
    public Session(DateTime startTime, Movie movie, Cinema cinema)
    {
        StartTime = startTime;
        Movie = movie;
        Cinema = cinema;
        movie.Sessions.Add(this);
        AvailableSeats = this.Cinema.Seats;
    }
    
    public Movie Movie { get; set; }

    public Cinema Cinema { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime => StartTime.AddMinutes(Movie.Duration + 20);

    public List<Seat> AvailableSeats { get; set; }

    public void sellSeat(Seat seat)
    {
        AvailableSeats.Remove(seat);
    }
}

    
    
    
    