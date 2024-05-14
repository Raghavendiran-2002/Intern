using System.Runtime.Serialization;

namespace ClinicAPI.Exceptions
{
   
    internal class NoSuchDoctorException : Exception
    {
        string msg;
        public NoSuchDoctorException()
        {
            msg = "No Doctor Found";
        }
        public override string Message => msg;
    }
}