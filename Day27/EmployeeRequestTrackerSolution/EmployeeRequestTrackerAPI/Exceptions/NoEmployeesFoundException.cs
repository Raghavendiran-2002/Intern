using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{

    internal class NoEmployeesFoundException : Exception
    {
        string message;
        public NoEmployeesFoundException()
        {
            message = "No Employees Found";
        }
        public override string Message => message;
    }
}