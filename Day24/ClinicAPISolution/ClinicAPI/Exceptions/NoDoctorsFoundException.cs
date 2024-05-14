using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{

    internal class NoDoctorsFoundException : Exception
    {
        string msg;
        public NoDoctorsFoundException()
        {
            msg = "No Doctors Found";
        }
        public override string Message => msg;


    }
}