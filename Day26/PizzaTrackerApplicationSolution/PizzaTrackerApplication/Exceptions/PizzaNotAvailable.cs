using System.Runtime.Serialization;

namespace PizzaTrackerApplication.Services
{
    [Serializable]
    internal class PizzaNotAvailable : Exception
    {
        public PizzaNotAvailable()
        {
        }

        public PizzaNotAvailable(string? message) : base(message)
        {
        }

        public PizzaNotAvailable(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PizzaNotAvailable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}