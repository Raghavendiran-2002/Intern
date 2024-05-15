using RequestTrackerBLLibrary.Interfaces;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.BL
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new RequestTrackerContext());
            _repository = repo;
        }
        public async Task<Employee> Login(Employee employee)
        {
            var emp = await _repository.Get(employee.Id);
            if(emp != null)
            {
                if(emp.Password == emp.Password)
                    return emp;
            }
            return null;
        }

        public async Task<Employee> Register(Employee employee)
        {
           var result = await _repository.Add(employee);
           return result;
        }
        public async Task<string> CheckRole(int id)
        {
            var employee = await _repository.Get(id);
            return employee.Role;
        }
    }
}
