namespace CinemaTicketingSystem;

public class CinemaComplex
{
    public CinemaComplex(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public List<Cinema> Cinemas { get; set; } = new List<Cinema>();

    public Cinema AddCinema(string name)
    {
        var cinema = new Cinema(name);
        Cinemas.Add(cinema);
        return cinema;
    }

    public Cinema FindCinemaByName(string cinemaName)
    {
        foreach (var c in Cinemas)
        {
            if (c.Name == cinemaName)
            {
                return c;
            }
        }

        throw new Exception("No Cinema with provided name: " + cinemaName);
    }
    
    public List<Movie> Movies { get; set; } = new List<Movie>();

    public Movie AddMovie(string title, int duration, string rating)
    {
        var movie = new Movie(title, duration, rating);
        Movies.Add(movie);
        return movie;
    }

    public Movie FindMovieByTitle(string title)
    {
        foreach (var m in Movies)
        {
            if (m.Title == title)
            {
                return m;
            }
        }

        throw new Exception("Movie not found: " + title);
    }
    
    public List<Session> Sessions { get; set; } = new List<Session>();

    public Session ScheduleSession(DateTime startTime, string title, string cinemaName)
    {
        
        var movie = FindMovieByTitle(title);
        var cinema = FindCinemaByName(cinemaName);
        var session = new Session(startTime, movie, cinema);
        Sessions.Add(session);
        return session;
    }

    public List<TicketMachine> TicketMachines { get; set; } = new List<TicketMachine>();

    public TicketMachine AddTicketMachine(string id)
    {
        var tm = new TicketMachine(id, this);
        TicketMachines.Add(tm);
        return tm;
    }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
}