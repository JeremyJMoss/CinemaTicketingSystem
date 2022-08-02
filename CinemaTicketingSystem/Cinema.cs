namespace CinemaTicketingSystem;

public class Cinema
{
    public Cinema(string name)
    {
        Name = name;
    }
    
    public List<Seat> Seats { get; set; } = new List<Seat>();
    
    public string Name { get; set; }
}