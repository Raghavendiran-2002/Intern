using MovieBookingModelLibrary;
using MovieBookingSystemDALLibrary;

namespace MovieBookingBLLibrary
{
    public class MovieBLL : IMovieService
    {
        public static MovieRepository movies = new MovieRepository();

      
        
        public void ListAllMovies()
        {
            foreach (Movie movie in movies.GetAll())
            {
                Console.WriteLine(movie + "\n");
            }
        }

        public string ChooseMovieName()
        {
            int movieInd = 1;
            Console.WriteLine("List of All Available Movies\n");
            movies.GetAll().ForEach(movie => {
               Console.WriteLine( movieInd + " " + movie.Title);
                movieInd++;
            });
            Console.WriteLine("Choose Movie Index : ");
            int ind = Convert.ToInt32(Console.ReadLine());
            movieInd = 1;
            string Mname = "";
            movies.GetAll().ForEach(movie => {
                movieInd++;
                if (movieInd == ind)
                    Mname = movie.Title;
            });
            return Mname;
        }
        public void ListScreenTiming(string movieName)

        {
            Movie mov = movies.Get(movieName);
            if (mov.Equals(null))
                Console.WriteLine("Movie Title Not Available");
            int showcount = 0;
            foreach (DateTime st in mov.ScreeningTimes)
            {
                if (DateTime.Now < st)
                {
                    showcount++;
                    Console.WriteLine(showcount + " " + st );
                }
            }
            // No show timing movies found
            if (showcount == 0)
                throw new UserException("No show available");
        }
        
        public int LenghtOfScreenTiming(string movie)
        {
            Movie mov = movies.Get(movie);
            return mov.ScreeningTimes.Count;
        }
        public DateTime ChooseScreenTime(string movieTitle,int cnt)
        {
            Movie mov = movies.Get(movieTitle);
                if (mov.Title.Equals(movieTitle))
                {
                    int showcount = 0;
                    foreach (DateTime st in mov.ScreeningTimes)
                    {
                        if (DateTime.Now < st)
                        {
                            showcount++;
                        }
                        if (showcount.Equals(cnt))
                        {
                            Console.WriteLine(showcount + " " + st + "\n");
                            return st;
                        }
                    }
                }
            
            return DateTime.MinValue;
        }
        public bool isMovieListed(string movieName)
        {
            if (movies.Get(movieName).Equals(null)) 
               return true;
            return false;
        }
        
    }
}
