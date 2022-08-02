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
}