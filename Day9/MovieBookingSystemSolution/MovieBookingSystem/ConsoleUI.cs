using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystem
{
    public class ConsoleUI
    {
        /// <summary>
        /// Print Movie Details
        /// </summary>
        /// <param name="movie"></param>
        public void Print(Movie movie)
        {
            Console.WriteLine($"Movie Id : {movie.Id}\nTitle : {movie.Title}\nGenre : {movie.Genre}\nDuration : {movie.Duration}\nScreeningTimes : {movie.ScreeningTimes.ToString()}");
        }
        /// <summary>
        /// Print Booking
        /// </summary>
        /// <param name="booking"></param>
        public void Print(Booking booking)
        {
            Console.WriteLine($"Booking Id : {booking.Id}\nCustomerName : {booking.CustomerName}\nContactInformation : {booking.ContactInformation}\nSelectedMovie : {booking.SelectedMovie}\nScreeningTime : {booking.ScreeningTime}\nNumberOfTickets : {booking.NumberOfTickets}");
        }

        public void GetMoviesasdas() {
            Console.WriteLine("Enter movie details:");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Duration: ");
            string duration = Console.ReadLine();

            //Movie movie = new Movie( title, genre, duration);

            Console.WriteLine("Enter screening times (press Enter to finish):");
            while (true)
            {
                Console.Write("Screening Time (yyyy-MM-dd HH:mm): ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (DateTime.TryParse(input, out DateTime screeningTime))
                {
                    //movie.ScreeningTimes.Add(screeningTime);
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter date in format: yyyy-MM-dd HH:mm");
                }
            }
            return ;
        }  

    }
}
