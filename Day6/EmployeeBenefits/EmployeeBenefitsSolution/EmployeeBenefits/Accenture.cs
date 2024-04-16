using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits
{
    public class Accenture : Employee,GovtRulesInterface
    {
        public Accenture(int id, string name, string dept, string desc, double salary) : base(id, name, dept, desc, salary) { }

        public double EmployeePF(double basicSalary)
        {
            return  (0.12 * basicSalary ) + (0.12 * basicSalary);
            
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public string LeaveDetails()
        {
            return "2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year";
        }
    }
}
