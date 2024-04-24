using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class BookingConfirmation
    {

        public  int Id { get; set; }
        public  string BookingReference { get; set; }
        public   string Movie { get; set; }
        public  DateTime ScreeningTime {get; set;}

        public  double TotalCost { get; set;} 

        public BookingConfirmation(int id, string bookingReference, string movie, DateTime screenTime,  double totalCost)
        {
            Id = id;
            BookingReference = bookingReference;
            Movie = movie;
            ScreeningTime = screenTime;
            TotalCost = totalCost;
        }
        public BookingConfirmation(string bookingReference, string movie, DateTime screenTime, double totalCost)
        {
            BookingReference = bookingReference;
            Movie = movie;
            ScreeningTime = screenTime;
            TotalCost = totalCost;
        }

        
        public override string ToString()
        {
            return "BookingConfirmation Id : " + Id + "\nBookingReference : " + BookingReference +
                "\nMovie : " + Movie + "\nScreeningTime : " + ScreeningTime +
                "\nTotalCost : " + TotalCost;
        }
    }
}
