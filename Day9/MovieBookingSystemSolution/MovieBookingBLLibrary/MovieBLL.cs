using MovieBookingModelLibrary;
using MovieBookingSystemDALLibrary;

namespace MovieBookingBLLibrary
{
    public class MovieBLL : IMovieService
    {
        MovieRepository movies = new MovieRepository();

      
        public void InitMovies()
        {  
            movies.Add(new Movie("The Dark Knight", "Action", new DateTime(2024, 4, 22, 18, 0, 0),new List<DateTime>() { new DateTime(2024,2,23), new DateTime(2024,5,1)}));
            movies.Add(new Movie("Schindler's List", "Biography",  new DateTime(2024, 4, 22, 20, 30, 0)));
            movies.Add(new Movie("Pulp Fiction", "Crime", new DateTime(2024, 4, 23, 10, 0, 0)));
            movies.Add(new Movie("The Lord of the Rings: The Return of the King", "Adventure", new DateTime(2024, 4, 23, 13, 0, 0)));
            movies.Add(new Movie("Forrest Gump", "Drama",  new DateTime(2024, 4, 23, 16, 0, 0)));
            movies.Add(new Movie("Inception", "Action", new DateTime(2024, 4, 23, 19, 0, 0)));
            movies.Add(new Movie("The Matrix", "Action", new DateTime(2024, 4, 23, 21, 30, 0)));
            movies.Add(new Movie("Interstellar", "Adventure", new DateTime(2024, 4, 24, 10, 0, 0)));
            movies.Add(new Movie("Saving Private Ryan", "Drama",  new DateTime(2024, 4, 24, 13, 0, 0)));
            movies.Add(new Movie("The Green Mile", "Crime",  new DateTime(2024, 4, 24, 15, 30, 0)));
            movies.Add(new Movie("The Lion King", "Animation",  new DateTime(2024, 4, 24, 18, 0, 0)));
            movies.Add(new Movie("Gladiator", "Action",  new DateTime(2024, 4, 24, 20, 30, 0)));
        }
        public List<Movie> ListAllMovies()
        {
          return   movies.GetAll();
        }
        
    }
}
