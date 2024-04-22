using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class Booking
    {

        public required int Id { get; set; }
        public required string CustomerName { get; set; }
        public required string ContactInformation { get; set; }

        public required Movie SelectedMovie { get; set; }
        public required DateTime ScreeningTime {  get; set; }
        public required int NumberOfTickets { get; set; }
        public Booking(int id, string customerName, string contactInformation, Movie selectedMovie, DateTime screeningTime, int numberOfTickets)
        {
            Id = id;
            CustomerName = customerName;
            ContactInformation = contactInformation;
            SelectedMovie = selectedMovie;
            ScreeningTime = screeningTime;
            NumberOfTickets = numberOfTickets;
        }
    }
}
