namespace CinemaTicketingSystem;

public class Ticket
{
    public Seat Serat { get; set; }
    
    public Session Session { get; set; }
    
    public DateTime Issued { get; set; }
}