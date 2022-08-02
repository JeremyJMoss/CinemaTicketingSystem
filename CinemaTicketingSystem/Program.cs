namespace CinemaTicketingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        BuildDummyData();
    }

    public static void BuildDummyData()
    {
        var complex = new CinemaComplex("Capt'n Flix", "123 Hollywood Lane, Penrith");

        foreach(var cinemaName in new[] {"Cinema 1", "Cinema 2", "Imax"})
        {
            var cinema = complex.AddCinema(cinemaName);
            foreach (var row in "ABCDE")
            {
                for (int i = 1; i <= 10; i++)
                {
                    cinema.AddSeat($"{row}{i}");
                }
            }
        }
        
        complex.AddMovie("Lord of the Strings", 110, "R");
        complex.AddMovie("Char Wars", 75, "M");
        complex.AddMovie("Byte Club", 90, "G");

        complex.ScheduleSession(DateTime.Parse("2022-08-02 10:30"), "Char Wars", "Cinema 2");
        complex.ScheduleSession(DateTime.Parse("2022-08-03 14:00"), "Char Wars", "Cinema 2");
        complex.ScheduleSession(DateTime.Parse("2022-08-03 13:30"), "Byte Club", "Cinema 1");
        
        var ticketMachine = complex.AddTicketMachine("TM1");

        Console.WriteLine($"Welcome to {complex.Name}");
        Console.WriteLine($"Ticket Machine: {ticketMachine.Id}");
        Console.WriteLine("Movies (Now Showing)");
        foreach (var m in ticketMachine.Movies)
        {
            Console.WriteLine(m.Title);
        }
        Console.Write("Please enter a movie title:");
        var title = Console.ReadLine();
        var movie = complex.FindMovieByTitle(title);
        
        Console.WriteLine("Sessions");

        int sessionIndex = 1;
        foreach (var s in movie.FutureSessions)
        {
            Console.WriteLine($"{sessionIndex++} - Cinema: {s.Cinema.Name} Time: {s.StartTime}");
        }
        
        Console.WriteLine("Please select a session: ");
        int selectedSessionIndex = int.Parse(Console.ReadLine());

        var session = movie.FutureSessions[selectedSessionIndex - 1];
        
    }
}
