using MovieBookingModelLibrary;
using MovieBookingSystemDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibrary
{
    public class BookingConfirmationBLL
    {
        BookingConfirmationRepository booking = new BookingConfirmationRepository();

        static double FindTotalCost(int ticket) {
            double subT = ticket * 150;
            return ((ticket * 150) * 0.18) + (ticket * 150);
        }
        public void BookConfirmationTicket(string movie, string username, DateTime screentime, int noOfTik) {
            double cost = FindTotalCost(noOfTik);
            Console.WriteLine($"Comfirmation\n Username : {username}\nMovie : {movie}");
            Console.WriteLine($"ScreenTime : {screentime}\nNumber Of Ticker : {noOfTik}\nCost : {cost}");
            Console.WriteLine("Do you want to Confirm(y/n) : ");
            string res = Console.ReadLine() ?? "n";
            if (res == "y") { 
                booking.Add(new BookingConfirmation(username, movie, screentime, FindTotalCost(noOfTik)));
                Console.WriteLine("Successfully booked" + booking.Get(username).ToString());
                return;
            }
            Console.WriteLine("Canceled Booking");

        }
        public void ListBookingConfirmation()
        {
            if (booking.GetAll() == null) { 
                Console.WriteLine("No Booking COnfirmation Found!!!"); 
                return; 
            }           
            foreach (BookingConfirmation b in booking.GetAll())
            {
                Console.WriteLine(b + "\n");
            }
        }
    }

    
}
