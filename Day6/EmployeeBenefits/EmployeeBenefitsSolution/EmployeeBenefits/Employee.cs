using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EmployeeBenefits
{
    public class Employee
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        public  double BasicSalary { get; set; }
        public Employee() {
            Id = 0;
            Name = string.Empty;
            Designation = string.Empty;
            Department = string.Empty;
            BasicSalary = 0;    
        }
        public Employee(int id, string name, string desc, string dept, double salary)
        {
            Id = id;
            Name  = name;
            Designation = desc;
            Department = dept;
            BasicSalary = salary;
        }

        public override string ToString()
        {
            return $"Employee ID :  {Id}\nName : {Name}\nDepartment : {Department}\nDesignation : {Designation}\nBasic Salary : {BasicSalary}";
        }

       
    }
}
