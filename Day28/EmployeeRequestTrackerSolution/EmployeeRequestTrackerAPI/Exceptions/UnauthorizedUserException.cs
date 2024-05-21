namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        string msg;
        public UnauthorizedUserException(string m)
        {
            msg = m;
        }
        public override string Message => msg;
    }
}
