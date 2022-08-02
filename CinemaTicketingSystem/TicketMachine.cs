namespace CinemaTicketingSystem;

public class TicketMachine
{
    public TicketMachine(string id, CinemaComplex complex)
    {
        Id = id;
        CinemaComplex = complex;
    }

    public CinemaComplex CinemaComplex { get; set; }
    public string Id { get; set; }

    public List<Ticket> Tickets = new List<Ticket>();

    public Ticket AddTicket(Session session, Seat seat)
    {
        var t = new Ticket(session, seat);
        Tickets.Add(t);
        return t;
    }

    public List<Movie> Movies
    {
        get
        {
            var nowShowingMovies = new List<Movie>();
            foreach (var movie in CinemaComplex.Movies)
            {
                if (movie.HasFutureSession)
                {
                    nowShowingMovies.Add(movie);
                }
            }

            return nowShowingMovies;
        }   
    }
    
    
}