using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibrary
{
    public class UserException: Exception
    {
       public UserException(string msg):base(msg)
        {
            Console.WriteLine(msg);
        }
        public class UserValidationException : Exception
        {
            public UserValidationException(string message) : base(message) { }
        }

    }
}
