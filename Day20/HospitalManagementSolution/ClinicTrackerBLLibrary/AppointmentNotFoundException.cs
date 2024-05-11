using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public class AppointmentNotFoundException : Exception
    {
        string msg;
        public AppointmentNotFoundException()
        {
            msg = "No Appointment Found!";
        }

        public override string Message => msg;
    }
}
