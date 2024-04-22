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
        BookingRepository booking = new BookingRepository();

        public void BookTicket()
        {
            Console.WriteLine("Customer Name : ");
            string cn = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Contact Information : ");
            string ci = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Selected Movie : ");
            int mo = Convert.ToInt32(Console.ReadLine());
            Movie m =new MovieRepository().Get(mo);
            Console.WriteLine("Number Of Tickets : ");
            int tik = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ScreeningTime : ");
            DateTime dt;
            if(DateTime.TryParse(Console.ReadLine(), out dt)) 
            {
                Booking b = new Booking(cn,ci,m,dt,tik);
                Console.WriteLine(cn + "   Done ");
                booking.Add(b);
            }
        }
        public List<Booking> ListAllBooking()
        {
            return booking.GetAll();
        }
    }
}
