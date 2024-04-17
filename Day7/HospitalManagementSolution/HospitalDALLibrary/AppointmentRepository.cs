using HospitalModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;
        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {

            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item)) return null;
            _appointments.Add(GenerateId(), item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var doc = _appointments[key];
                _appointments.Remove(key);
                return doc;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            return _appointments.ContainsKey(key) ? _doctors[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }


        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.Id))
            {
                _appointments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
