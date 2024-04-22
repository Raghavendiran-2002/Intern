using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystemDALLibrary
{
    public class BookingRepository : IRepository<int, Booking>
    {
        readonly Dictionary<int, Booking> _bookings;

        public BookingRepository()
        {
            _bookings = new Dictionary<int, Booking>();
        }
        int GenerateId()
        {
            if(_bookings.Count == 0)
                    return 0;
            int id = _bookings.Keys.Max();
            return ++id;
        }
        public Booking Add(Booking item)
        {
            if (_bookings.ContainsValue(item)) return null;
            item.Id = GenerateId();
            _bookings.Add(item.Id, item);
            return item;

        }


        public Booking Get(int key)
        {
            return _bookings.ContainsKey(key) ? _bookings[key] : null;
        }

        public List<Booking> GetAll()
        {
            if (_bookings.Count == 0) return null;
            return _bookings.Values.ToList();
        }

        public Booking Update(Booking item)
        {
            if (_bookings.ContainsKey(item.Id))
            {
                _bookings[item.Id] = item;
                return item;
            }
            return null;
        }

        public Booking Delete(int key)
        {
            if (_bookings.ContainsKey(key))
            {
                var mov = _bookings[key];
                _bookings.Remove(key);
                return mov;

            }return null;
        }
    }
}
