namespace EmployeeBenefits
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CTS ctsEmployee = new CTS(101, "Tharun" , "HR", "Manager" , 50000);
            Accenture accentureEmployee = new Accenture(102, "Pradesh", "Software", "Lead", 100000);
            Console.WriteLine("\nCTS Employee : \n");
            Console.WriteLine(ctsEmployee+ "\n");
            Console.WriteLine($"Employee PF : {ctsEmployee.EmployeePF(ctsEmployee.BasicSalary)}\n{ctsEmployee.LeaveDetails()}\nGratuity Amount : {ctsEmployee.GratuityAmount(6,ctsEmployee.BasicSalary)}");
          
           
            Console.WriteLine("\n\nAccenture Employee : \n");
            Console.WriteLine(accentureEmployee);
            Console.WriteLine($"Employee PF : {accentureEmployee.EmployeePF(accentureEmployee.BasicSalary)}\n{accentureEmployee.LeaveDetails()}\nGratuity Amount : {accentureEmployee.GratuityAmount(6, accentureEmployee.BasicSalary)}");
        }
    }
}
