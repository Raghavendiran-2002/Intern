using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystemDALLibrary
{
    public class MovieRepository : IRepository<int, Movie>
    {
        readonly Dictionary<int, Movie> _movies;

        public MovieRepository()
        {
            _movies = new Dictionary<int, Movie>();
        }

        int GenerateId()
        {
            if(_movies.Count == 0)
                    return 0;
            int id = _movies.Keys.Max();
            return ++id;
        }
        public Movie Add(Movie item)
        {
            if (_movies.ContainsValue(item)) return null;
            item.Id = GenerateId();

            _movies.Add(item.Id,item);
            return item;

        }


        public Movie Get(int key)
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
            if (_movies.ContainsKey(item.Id))
            {
                _movies[item.Id] = item;
                return item;
            }
            return null;
        }

        public Movie Delete(int key)
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
