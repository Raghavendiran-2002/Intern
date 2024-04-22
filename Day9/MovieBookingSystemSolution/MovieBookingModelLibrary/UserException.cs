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

        }

       
    }
}
