using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystemDALLibrary
{
    public class MovieRepository : IRepository<string, Movie>
    {
        readonly Dictionary<string, Movie> _movies;

        public MovieRepository()
        {
            _movies = new Dictionary<string, Movie>();
            _movies.Add("Fall", new Movie("Fall", "Action", "2.7hr", new List<DateTime>() { new DateTime(2024, 4, 25), new DateTime(2024, 4, 24), new DateTime(2024, 4, 26), new DateTime(2024, 4, 27), new DateTime(2024, 4, 28) }));
            _movies.Add("Ghilli", new Movie("Ghilli", "Action", "2.5hr", new List<DateTime>() { new DateTime(2024, 4, 25), new DateTime(2024, 4, 24) }));
            _movies.Add("Don",new Movie("Don", "Biography", "3hr", new List<DateTime>() { new DateTime(2024, 4, 24), new DateTime(2024,4, 25) }));
            
        }

        public Movie Add(Movie item)
        {
            if (_movies.ContainsValue(item)) return null;

            _movies.Add(item.Title,item);
            return item;

        }


        public Movie Get(string key)
        {
            return _movies.ContainsKey(key) ? _movies[key] : null;
        }

        public List<Movie> GetAll()
        {
            if (_movies.Count == 0) return null;
            return _movies.Values.ToList();
        }

        public Movie Update(Movie item)
        {
            if (_movies.ContainsKey(item.Title))
            {
                _movies[item.Title] = item;
                return item;
            }
            return null;
        }

        public Movie Delete(string key)
        {
            if (_movies.ContainsKey(key))
            {
                var mov = _movies[key];
                _movies.Remove(key);
                return mov;

            }return null;
        }
    }
}
