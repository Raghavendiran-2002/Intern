using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class BookingConfirmation
    {

        public required int Id { get; set; }
        public required string BookingReference { get; set; }
        public  required Movie Movie { get; set; }
        public required DateTime ScreeningTime {get; set;}

        public required float TotalCost { get; set;} 

        public BookingConfirmation(int id, string bookingReference, Movie movie, DateTime screenTime,  float totalCost)
        {
            Id = id;
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
