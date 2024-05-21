namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UnableToRegisterException : Exception
    {
        string msg;
        public UnableToRegisterException(string m)
        {
            msg = m;
        }
        public override string Message => msg;
    }
}
