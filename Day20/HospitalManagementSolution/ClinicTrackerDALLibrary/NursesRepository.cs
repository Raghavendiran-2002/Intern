using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class NursesRepository : IRepository<int, Nurses>
    {
        readonly Dictionary<int, Nurses> _nurses;

        public NursesRepository()
        {
            _nurses = new Dictionary<int, Nurses>();
        }
        int GenerateId()
        {
            if (_nurses.Count == 0)
                return 1;
            int id = _nurses.Keys.Max();
            return ++id;
        }

        public Nurses Add(Nurses item)
        {
            if (_nurses.ContainsValue(item))
            {
                return null;
            }
            _nurses.Add(GenerateId(), item);
            return item;
        }

        public Nurses Delete(int key)
        {
            if (_nurses.ContainsKey(key))
            {
                var nurses = _nurses[key];
                _nurses.Remove(key);
                return nurses;
            }
            return null;
        }

        public Nurses Get(int key)
        {
            return _nurses.ContainsKey(key) ? _nurses[key] : null;
        }

        public List<Nurses> GetAll()
        {
            if (_nurses.Count == 0)
                return null;
            return _nurses.Values.ToList();
        }

        public Nurses Update(Nurses item)
        {
            if (_nurses.ContainsKey(item.Id))
            {
                _nurses[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
