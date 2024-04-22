using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystemDALLibrary
{
    public class BookingConfirmationRepository : IRepository<string, BookingConfirmation>

    {
        readonly Dictionary<string, BookingConfirmation> _bookingConfirmations;

        public BookingConfirmationRepository()
        {
            _bookingConfirmations = new Dictionary<string, BookingConfirmation>();
        }
        
        public BookingConfirmation Add(BookingConfirmation item)
        {
            if (_bookingConfirmations.ContainsValue(item)) return null;

            _bookingConfirmations.Add(item.BookingReference, item);
            return item;

        }


        public BookingConfirmation Get(string key)
        {
            return _bookingConfirmations.ContainsKey(key) ? _bookingConfirmations[key] : null;
        }

        public List<BookingConfirmation> GetAll()
        {
            if (_bookingConfirmations.Count == 0) return null;
            return _bookingConfirmations.Values.ToList();
        }

        public BookingConfirmation Update(BookingConfirmation item)
        {
            if (_bookingConfirmations.ContainsKey(item.BookingReference))
            {
                _bookingConfirmations[item.BookingReference] = item;
                return item;
            }
            return null;
        }

        public BookingConfirmation Delete(string key)
        {
            if (_bookingConfirmations.ContainsKey(key))
            {
                var mov = _bookingConfirmations[key];
                _bookingConfirmations.Remove(key);
                return mov;

            }
            return null;
        }
    }
}
