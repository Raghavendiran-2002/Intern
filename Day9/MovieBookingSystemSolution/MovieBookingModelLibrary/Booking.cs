using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class Booking
    {

        public  int Id { get; set; }
        public  string CustomerName { get; set; }
        public  string ContactInformation { get; set; }

        public  Movie SelectedMovie { get; set; }
        public  DateTime ScreeningTime {  get; set; }
        public  int NumberOfTickets { get; set; }
        public Booking(int id, string customerName, string contactInformation, Movie selectedMovie, DateTime screeningTime, int numberOfTickets)
        {
            Id = id;
            CustomerName = customerName;
            ContactInformation = contactInformation;
            SelectedMovie = selectedMovie;
            ScreeningTime = screeningTime;
            NumberOfTickets = numberOfTickets;
        }
        public Booking(string customerName, string contactInformation, Movie selectedMovie, DateTime screeningTime, int numberOfTickets)
        {
            CustomerName = customerName;
            ContactInformation = contactInformation;
            SelectedMovie = selectedMovie;
            ScreeningTime = screeningTime;
            NumberOfTickets = numberOfTickets;
        }
        public override string ToString()
        {
            return "Booking Id : " + Id  + "\nCustomerName : " + CustomerName +
                "\nContactInformation : " + ContactInformation + "\nSelected Movie : " 
                + SelectedMovie.Title?? "none" + "\nScreeningTime : " + ScreeningTime +
                "\nNumberOfTickets : " + NumberOfTickets;
        }
    }
}
