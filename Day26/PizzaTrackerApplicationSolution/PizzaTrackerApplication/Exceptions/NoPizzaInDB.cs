using System.Runtime.Serialization;

namespace PizzaTrackerApplication.Exceptions
{
    [Serializable]
    internal class NoPizzaInDB : Exception
    {
        public NoPizzaInDB()
        {
        }

        public NoPizzaInDB(string? message) : base(message)
        {
        }

        public NoPizzaInDB(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoPizzaInDB(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}