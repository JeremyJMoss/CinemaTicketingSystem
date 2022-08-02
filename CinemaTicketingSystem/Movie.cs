namespace CinemaTicketingSystem;

public class Movie
{
    public Movie(string title, int duration, string rating)
    {
        Title = title;
        Duration = duration;
        Rating = rating;
    }

    public string Title { get; set; }

    public int Duration { get; set; }

    public string Rating { get; set; }

    public List<Session> Sessions { get; set; } = new List<Session>();

    public List<Session> FutureSessions
    {
        get
        {
            var result = new List<Session>();
            foreach (var s in Sessions)
            {
                if (s.StartTime > DateTime.Now)
                {
                    result.Add(s);
                }
            }

            return result;
        }
    }
    public bool HasFutureSession
    {
        get
        {
            return FutureSessions.Count > 0;   
        }
    }
}