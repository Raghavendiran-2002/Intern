namespace MovieBookingModelLibrary
{
    public class Movie
    {
        public  string Title { get; set; }
        public  string Genre { get; set; } 
        public  string Duration { get; set; }
        public  List<DateTime> ScreeningTimes { get; set; }

        public Movie(string title, string genre, string duration, List<DateTime> screentime)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
            ScreeningTimes = screentime;
        }
       

        public override string ToString()
        {
            string st = "";
            foreach(DateTime d in ScreeningTimes)
            {
                st += d.ToString() + "\t";
            }
            return "\n\nMovie Title : " + Title +
                "\nGenre : " + Genre + "\nDuration : "
                + Duration + "\nScreeningTime : " + st;
              
        }
    }
}
