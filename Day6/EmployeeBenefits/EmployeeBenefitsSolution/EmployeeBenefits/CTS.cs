using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits
{
    public class CTS : Employee,GovtRulesInterface
    {
        public CTS(int id, string name, string dept, string desc, double salary)  : base(id, name, dept, desc, salary){ }
        public double EmployeePF(double basicSalary)
        {
            return (0.12 * basicSalary) + (0.0833 * basicSalary) + (0.0367 * basicSalary);
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if(serviceCompleted > 20) {
                return 3 * basicSalary;
            }
            else if(serviceCompleted > 10)
            {
                return 2 * basicSalary;
            }
            else if( serviceCompleted > 5)
            {
                return basicSalary;
            }
            else
            {
                return 0;
            }
        }

        public string LeaveDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year";
        }
    }
}
