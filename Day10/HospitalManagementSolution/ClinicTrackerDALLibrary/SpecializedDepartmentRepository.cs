using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerDALLibrary
{
    public class SpecializedDepartmentRepository : IRepository<int, SpecializedDepartment>
    {
        readonly Dictionary<int, SpecializedDepartment> _Specializeddepartments;
        public SpecializedDepartmentRepository()
        {
            _Specializeddepartments = new Dictionary<int, SpecializedDepartment>();
        }
        int GenerateId()
        {
            if (_Specializeddepartments.Count == 0)
                return 1;
            int id = _Specializeddepartments.Keys.Max();
            return ++id;
        }
        public SpecializedDepartment Add(SpecializedDepartment item)
        {
            if (_Specializeddepartments.ContainsValue(item))
            {
                return null;
            }
            _Specializeddepartments.Add(GenerateId(), item);
            return item;
        }

        public SpecializedDepartment Delete(int key)
        {
            if (_Specializeddepartments.ContainsKey(key))
            {
                var specializedDepartment = _Specializeddepartments[key];
                _Specializeddepartments.Remove(key);
                return specializedDepartment;
            }
            return null;
        }

        public SpecializedDepartment Get(int key)
        {
            return _Specializeddepartments.ContainsKey(key) ? _Specializeddepartments[key] : null;
        }

        public List<SpecializedDepartment> GetAll()
        {
            if (_Specializeddepartments.Count == 0)
                return null;
            return _Specializeddepartments.Values.ToList();
        }

        public SpecializedDepartment Update(SpecializedDepartment item)
        {
            if (_Specializeddepartments.ContainsKey(item.Id))
            {
                _Specializeddepartments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
