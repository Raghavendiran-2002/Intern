namespace MovieBookingModelLibrary
{
    public class Movie
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; } 
        public required string Duration { get; set; }
        public required List<DateTime> ScreeningTimes { get; set; }

        public Movie(int id, string title, string genre, string duration)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Duration = duration;
            ScreeningTimes = new List<DateTime>();
        }

        public void AddScreeningTime(DateTime time)
        {
            ScreeningTimes.Add(time);   
        }
        public override string ToString()
        {
            return "Movie Id : " + Id + "\nTitle : " + Title +
                "\nGenre : " + Genre + "\nDuration : "
                + Duration + "\nScreeningTime : " + ScreeningTimes.ToString();
              
        }
    }
}
