namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public double Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
        }
        public Employee(int id, string name, DateTime dateOfBirth, double salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        /// <summary>
        /// Create new employee from console by user input
        /// </summary>
        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }

        /// <summary>
        /// Print Employee Details
        /// </summary>
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }
    }
}
