using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointments>
    {
        readonly Dictionary<int, Appointments> _Appointments;
        public AppointmentRepository()
        {
            _Appointments = new Dictionary<int, Appointments>();
        }

        int GenerateId()
        {
            if (_Appointments.Count == 0)
                return 1;
            int id = _Appointments.Keys.Max();
            return ++id;
        }
        public Appointments Add(Appointments item)
        {
            if (_Appointments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _Appointments.Add(item.Id, item);
            return item;
        }

        public Appointments Delete(int key)
        {
            if (_Appointments.ContainsKey(key))
            {
                var appointments = _Appointments[key];
                _Appointments.Remove(key);
                return appointments;
            }
            return null;
        }

        public Appointments Get(int key)
        {
            return _Appointments.ContainsKey(key) ? _Appointments[key] : null;
        }

        public List<Appointments> GetAll()
        {
            if (_Appointments.Count == 0)
                return null;
            return _Appointments.Values.ToList();
        }

        public Appointments Update(Appointments item)
        {
            if (_Appointments.ContainsKey(item.Id))
            {
                _Appointments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
