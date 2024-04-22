using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystemDALLibrary
{
    public class BookingConfirmationRepository : IRepository<int, BookingConfirmation>

    {
        readonly Dictionary<int, BookingConfirmation> _bookingConfirmations;

        public BookingConfirmationRepository()
        {
            _bookingConfirmations = new Dictionary<int, BookingConfirmation>();
        }
        int GenerateId()
        {
            if (_bookingConfirmations.Count == 0)
                return 0;
            int id = _bookingConfirmations.Keys.Max();
            return ++id;
        }
        public BookingConfirmation Add(BookingConfirmation item)
        {
            if (_bookingConfirmations.ContainsValue(item)) return null;
            item.Id = GenerateId();

            _bookingConfirmations.Add(item.Id, item);
            return item;

        }


        public BookingConfirmation Get(int key)
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
            if (_bookingConfirmations.ContainsKey(item.Id))
            {
                _bookingConfirmations[item.Id] = item;
                return item;
            }
            return null;
        }

        public BookingConfirmation Delete(int key)
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
