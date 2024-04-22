using MovieBookingModelLibrary;
using MovieBookingSystemDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibrary
{
    public class BookingBLL
    {
        public static BookingRepository booking = new BookingRepository();

        public void BookTicket(MovieBLL mov, BookingConfirmationBLL bookConB)
        {
            Console.WriteLine("\n\nCustomer Name :");
            string cn = Console.ReadLine();
            Console.WriteLine("\nCustomer Information :");
            string ci = Console.ReadLine();
            //Console.WriteLine("\nSelected Movie :");
            //string movieTitle = Console.ReadLine();
            string movieTitle = mov.ChooseMovieName();
            if (mov.isMovieListed(movieTitle))
                throw new UserException("Movie Not avaialble");
            Console.WriteLine("Available ScreenTiming ");
            mov.ListScreenTiming(movieTitle);
            Console.WriteLine("Choose in 1-" + mov.LenghtOfScreenTiming(movieTitle));
            int cnt = Convert.ToInt32(Console.ReadLine());
            DateTime st = mov.ChooseScreenTime(movieTitle, cnt);
            if (st < DateTime.Now)
                throw new UserException("Invalid ScreenTiming");
            Console.WriteLine("\nNumberOfTickets :");
            int tk = Convert.ToInt32(Console.ReadLine());
            booking.Add(new Booking(cn, ci, movieTitle, st, tk));
            Console.WriteLine("Booking Added!!!");
            ConfirmBooking(cn,movieTitle,st, tk , bookConB);
        }

        public void ListBooking()
        {
            if (booking.GetAll() == null)
            {
                Console.WriteLine("No Booking Found!!!");
                return;
            }
            foreach (Booking b in booking.GetAll())
            {
                Console.WriteLine(b + "\n");
            }
        }

        public static void ConfirmBooking(string username, string movie, DateTime screentime, int noofTik, BookingConfirmationBLL book) 
        {
            book.BookConfirmationTicket(movie,username, screentime, noofTik);
        }

    }
}
