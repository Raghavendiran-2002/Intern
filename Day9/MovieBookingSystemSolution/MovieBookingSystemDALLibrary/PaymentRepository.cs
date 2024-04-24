using MovieBookingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingSystemDALLibrary
{
    public class PaymentRepository : IRepository<int, Payment>
    {
        readonly Dictionary<int, Payment> _payments;

        public PaymentRepository()
        {
            _payments = new Dictionary<int, Payment>();
        }
        int GenerateId()
        {
            if (_payments.Count == 0)
                return 0;
            int id = _payments.Keys.Max();
            return ++id;
        }
        public Payment Add(Payment item)
        {
            if (_payments.ContainsValue(item)) return null;
            item.Id = GenerateId();
            _payments.Add(item.Id, item);
            return item;

        }


        public Payment Get(int key)
        {
            return _payments.ContainsKey(key) ? _payments[key] : null;
        }

        public List<Payment> GetAll()
        {
            if (_payments.Count == 0) return null;
            return _payments.Values.ToList();
        }

        public Payment Update(Payment item)
        {
            if (_payments.ContainsKey(item.Id))
            {
                _payments[item.Id] = item;
                return item;
            }
            return null;
        }

        public Payment Delete(int key)
        {
            if (_payments.ContainsKey(key))
            {
                var mov = _payments[key];
                _payments.Remove(key);
                return mov;

            }
            return null;
        }
    }
}
