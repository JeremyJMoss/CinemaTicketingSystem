namespace CinemaTicketingSystem;

public class Ticket
{
    public Ticket(Session session, Seat seat)
    {
        Seat = seat;
        Session = session;
        Issued = DateTime.Now;
    }
    public Seat Seat { get; set; }
    
    public Session Session { get; set; }
    
    public DateTime Issued { get; set; }

    public void PrintTicket()
    {
        Console.WriteLine($"You have purchased a ticket for {this.Session.Movie.Title}");
        Console.WriteLine($"The movie starts at {this.Session.StartTime}");
        Console.WriteLine($"The movie ends at {this.Session.EndTime}");
        Console.WriteLine($"{this.Session.Cinema.Name}\tSeat: {this.Seat.Name}");
        Console.WriteLine($"Issued : {this.Issued}");
        Console.Write("\n");
    }
}