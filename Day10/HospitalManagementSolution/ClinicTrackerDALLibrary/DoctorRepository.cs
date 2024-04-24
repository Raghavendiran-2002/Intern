using ClinicTrackerModelLibrary;
using System.Collections.Immutable;
namespace ClinicTrackerDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }

        int GenerateId()
        {
            if (_doctors.Count == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _doctors.Add(item.Id, item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var doctor = _doctors[key];
                _doctors.Remove(key);
                return doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                var doctor = _doctors[key];
                return doctor;
            }
            return null;
            //return _doctors.ContainsKey(key) ? _doctors[key] : null;
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
