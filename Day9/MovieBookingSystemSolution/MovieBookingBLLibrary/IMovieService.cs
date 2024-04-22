using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibrary
{
    public interface IMovieService
    {
        void InitMovies();
        List<Movie> ListAllMovies();

    }
}
