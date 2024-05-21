namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UserNotActiveException : Exception
    {
        string msg;
        public UserNotActiveException(string m) {
            msg = m;
        }
        public override string Message => msg;
    }
}
