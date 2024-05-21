using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    internal class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No such employee present";
        }

        public override string Message => message;
    }
}