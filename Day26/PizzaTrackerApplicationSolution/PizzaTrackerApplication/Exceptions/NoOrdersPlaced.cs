using System.Runtime.Serialization;

namespace PizzaTrackerApplication.Services
{
    [Serializable]
    internal class NoOrdersPlaced : Exception
    {
        public NoOrdersPlaced()
        {
        }

        public NoOrdersPlaced(string? message) : base(message)
        {
        }

        public NoOrdersPlaced(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoOrdersPlaced(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}