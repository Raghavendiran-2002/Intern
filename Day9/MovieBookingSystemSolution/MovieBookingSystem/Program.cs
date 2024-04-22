using MovieBookingBLLibrary;
using MovieBookingModelLibrary;

namespace MovieBookingSystem
{
    public class Program
    {
        static MovieBLL movieB = new MovieBLL();
        static BookingBLL bookingB = new BookingBLL();
        static void ListMovies()
        {
            movieB.InitMovies();
            List<Movie> k = movieB.ListAllMovies();
            foreach (Movie movie in k)
            {
                Console.WriteLine(movie + "\n");
            }
        }
        static void ListBooking()
        {
            if(bookingB.ListAllBooking() == null)
            {
                Console.WriteLine("No booking done");
                return;
            }
            foreach(Booking b in bookingB.ListAllBooking()) {
                Console.WriteLine(b + "\n");
            } 
        }
        public static void BookTicket()
        {
            bookingB.BookTicket();
        }
        public static void MovieBooking()
        {
            
            while (true)
            {
                Console.WriteLine("Welcome to Movie Booking System");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Book Movies");
                Console.WriteLine("3. List Booking");
                int btn = Convert.ToInt32(Console.ReadLine());

                switch (btn)
                {
                    case 1:
                        ListMovies();
                        break;
                    case 2:
                        BookTicket();
                        break;
                    case 3:
                        ListBooking();
                        break;
                }
            }
            
        }
       
        static void Main(string[] args)
        {
            MovieBooking();
            
            
        }
    }
}
