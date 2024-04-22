using MovieBookingBLLibrary;
using MovieBookingModelLibrary;

namespace MovieBookingSystem
{
    public class Program
    {
        static MovieBLL movieB = new MovieBLL();
        static BookingBLL bookingB = new BookingBLL();
        static BookingConfirmationBLL bookingConfirmationB = new BookingConfirmationBLL();
        public static void BookingConfirmation()
        {
          //  bookingConfirmationB.BookConfirmationTicket();
        }
        public static void MovieBooking()
        {
            
            while (true)
            {
                Console.WriteLine("Welcome to Movie Booking System");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Book Movies");
                Console.WriteLine("3. List Booking");
                Console.WriteLine("4. List Booking Confirmation");

                int btn = Convert.ToInt32(Console.ReadLine());

                switch (btn)
                {
                    case 1:
                        movieB.ListAllMovies();
                        break;
                    case 2:
                        bookingB.BookTicket(movieB,bookingConfirmationB);
                        break;
                    case 3:
                        bookingB.ListBooking();
                        break;
                    case 4:
                        bookingConfirmationB.ListBookingConfirmation();
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
