namespace MovieBookingModelLibrary
{
    public class Movie
    {
        public  int Id { get; set; }
        public  string Title { get; set; }
        public  string Genre { get; set; } 
        public  DateTime Duration { get; set; }
        public  List<DateTime> ScreeningTimes { get; set; }

        public Movie(int id, string title, string genre, DateTime duration)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Duration = duration;
            ScreeningTimes = new List<DateTime>();
        }
        public Movie( string title, string genre, DateTime duration)
        {
            
            Title = title;
            Genre = genre;
            Duration = duration;
            ScreeningTimes = new List<DateTime>();
        }

        public Movie(string title, string genre, DateTime duration, List<DateTime> screentime)
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
            return "\n\nMovie Id : " + Id + "\nTitle : " + Title +
                "\nGenre : " + Genre + "\nDuration : "
                + Duration + "\nScreeningTime : " + st;
              
        }
    }
}
