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

        complex.AddCinema("cinema1");
        complex.AddCinema("cinema2");
        complex.AddCinema("Imax");

        complex.AddMovie("Lord of the Strings", 110, "R");
        complex.AddMovie("Char Wars", 75, "M");
        complex.AddMovie("Byte Club", 90, "G");

        var start = DateTime.Parse("2022-08-02 10:30");
        complex.ScheduleSession(start, "Char Wars", "cinema2");
    }
}
