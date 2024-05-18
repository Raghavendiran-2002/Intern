using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    internal class NoSuchRequestException : Exception
    {
        public NoSuchRequestException()
        {
        }

        public NoSuchRequestException(string? message) : base(message)
        {
        }

        public NoSuchRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoSuchRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}