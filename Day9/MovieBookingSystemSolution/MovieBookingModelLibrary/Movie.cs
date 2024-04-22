namespace MovieBookingModelLibrary
{
    public class Movie
    {
        public required string Title { get; set; }
        public required string Genre { get; set; } 
        public required string Duration { get; set; }
        public required List<DateTime> ScreeningTimes { get; set; }

        public Movie(string title, string genre, string duration)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
            ScreeningTimes = new List<DateTime>();
        }

        public void AddScreeningTime(DateTime time)
        {
            ScreeningTimes.Add(time);   
        }
    }
}
