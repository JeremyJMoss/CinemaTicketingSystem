using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace CinemaTicketingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        BuildDummyData();
    }

    public static void BuildDummyData()
    {
        const int rowWidth = 10; 
        var complex = new CinemaComplex("Capt'n Flix", "123 Hollywood Lane, Penrith");

        foreach(var cinemaName in new[] {"Cinema 1", "Cinema 2", "Imax"})
        {
            var cinema = complex.AddCinema(cinemaName);
            foreach (var row in "ABCDE")
            {
                for (int i = 1; i <= rowWidth; i++)
                {
                    cinema.AddSeat($"{row}{i}");
                }
            }
        }
        
        complex.AddMovie("Lord of the Strings", 110, "R");
        complex.AddMovie("Char Wars", 75, "M");
        complex.AddMovie("Byte Club", 90, "G");

        complex.ScheduleSession(DateTime.Parse("2022-08-06 10:30"), "Char Wars", "Cinema 2");
        complex.ScheduleSession(DateTime.Parse("2022-08-06 14:00"), "Char Wars", "Cinema 2");
        complex.ScheduleSession(DateTime.Parse("2022-08-06 13:30"), "Byte Club", "Cinema 1");
        
        var ticketMachine = complex.AddTicketMachine("TM1");
        while (true)
        {
            Console.WriteLine($"Welcome to {complex.Name}");
            Console.WriteLine($"Ticket Machine: {ticketMachine.Id}");
            Console.WriteLine("Movies (Now Showing)");
            foreach (var m in ticketMachine.Movies)
            {
                Console.WriteLine(m.Title);
            }

            Console.Write("Please enter a movie title: ");
            string title = Console.ReadLine();
            var movie = complex.FindMovieByTitle(title);

            Console.WriteLine("Sessions");

            int sessionIndex = 1;
            foreach (var s in movie.FutureSessions)
            {
                Console.WriteLine($"{sessionIndex++} - Cinema: {s.Cinema.Name} Time: {s.StartTime}");
            }

            Console.Write("Please select a session: ");
            int selectedSessionIndex = int.Parse(Console.ReadLine());

            var session = movie.FutureSessions[selectedSessionIndex - 1];

            string seatName = PrintAndSelectSeat(rowWidth, ticketMachine, session);

            var seat = complex.FindSeatByName(session, seatName);

            var ticket = ticketMachine.BuyTicket(session, seat);

            ticket.PrintTicket();
        }
    }

    public static string PrintAndSelectSeat(int rowWidth, TicketMachine ticketMachine, Session session)
    {
        Console.WriteLine("Here are the available seats for your chosen session");
        
        Console.WriteLine("\n");
        
        int count = 1;
        foreach (var s in ticketMachine.AvailableSeats(session))
        {
            
            // Stripping column letter from string and then parsing to an integer to compare with 
            // column number
            while (true)
            {
                int column = count % rowWidth == 0 ? rowWidth : count % rowWidth;
                if (int.Parse(Regex.Replace(s.Name, @"[A-Z]", "")) == column)
                {
                    Console.Write($"{s.Name} ");
                    break;
                }
                Console.Write("   ");
                count++;
            }

            if (count % rowWidth == 0)
            {
                Console.Write("\n");
            }
            else if (count % (rowWidth/2) == 0)
            {
                Console.Write("    ");
            }

            count++;
        }
        
        Console.WriteLine("\n");
        Console.Write("Please select a seat number: ");
        string seatName = Console.ReadLine();
        return seatName;
    }
}
