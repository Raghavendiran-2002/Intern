using HospitalModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;
        public DoctorRepository() {
            _doctors = new Dictionary<int, Doctor>();
        }

        int GenerateId()
        {
           
            if (_doctors.Count == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }
        public Doctor Add(Doctor doctor)
        {
            if (_doctors.ContainsValue(doctor)) return null;
            _doctors.Add(GenerateId(), doctor);
            return doctor;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key)) { 
                var doc = _doctors[key];
                _doctors.Remove(key);
                return doc;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return _doctors.ContainsKey(key) ? _doctors[key] : null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null;
            return _doctors.Values.ToList();
        }

        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsKey(item.Id))
            {
                _doctors[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
