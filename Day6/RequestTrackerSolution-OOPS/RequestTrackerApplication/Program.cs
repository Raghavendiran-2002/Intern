using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    using RequestTrackerModelLibrary;
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        /// <summary>
        /// Prints the list of operations performed by the application
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Search & Update Employee Name by ID");
            Console.WriteLine("5. Search & Delete Employee by ID");
            Console.WriteLine("0. Exit");
        }
        /// <summary>
        /// Get user input to perform specific operation
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        SearchAndUpdateNameOfEmployee();
                        break;
                    case 5:
                        SearchAndDeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        /// <summary>
        /// Add new Employee
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        /// <summary>
        ///  Print all the employees in the array
        /// </summary>
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        /// <summary>
        /// Get User input from the console
        /// </summary>
        /// <returns> int (ID) </returns>
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        /// <summary>
        /// Search and Print Employee By ID
        /// </summary>
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        /// <summary>
        /// Search and Update Name of Employee By ID
        /// </summary>
        void SearchAndUpdateNameOfEmployee()
        {
            Console.WriteLine("Please enter Employee ID to update name : ")
                ;
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if(employee == null) { 
                Console.WriteLine("Sorry, Employee ID is invalid!!!");
                return;
            }
            Console.WriteLine("Employee ID : " + id );
            PrintEmployee(employee);
            Console.WriteLine("Please enter new name : ");
            string? newname;
            newname = Console.ReadLine() ?? string.Empty;
            employee.Name = newname;
            Console.WriteLine("\n Employee updated !!!");
            PrintEmployee(employee);

            for(int i = 0; i < employees.Length; i++)
            {
                if (employees[i]?.Id == id) {
                    employees[i] = employee; 
                    break;
                }
            }
        }
        /// <summary>
        /// Search and Delete Employee By ID
        /// </summary>
        void SearchAndDeleteEmployee()
        {
            Console.WriteLine("Please enter ID to be deleted : ");
            int id = GetIdFromConsole(); 
            for(int i = 0; i < employees.Length; i++)
            {
                if (employees[i] .Id == id)
                {
                    employees[i] = null;
                    Console.WriteLine("Employee ID found and deleted!!!");
                    return;
                }
            }
            Console.WriteLine("Invalid Employee Id");
        }
        /// <summary>
        /// Search Employee By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee Object</returns>
        Employee? SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
        /// <summary>
        /// Create new Employee By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee Object</returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the type of employee");
            string type = Console.ReadLine();
            if (type == "Permanent")
                employee = new PermanentEmployee();
            else if (type == "Contract")
                employee = new ContractEmployee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }
        /// <summary>
        /// Print Employee by Employee Object
        /// </summary>
        /// <param name="employee"></param>

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

   
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}

