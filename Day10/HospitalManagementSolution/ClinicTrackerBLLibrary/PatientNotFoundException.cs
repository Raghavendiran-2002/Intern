using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public class PatientNotFoundException : Exception
    {
        string msg;
        public PatientNotFoundException()
        {
            msg = "No Patient Found!";
        }

        public override string Message => msg;
    }
}
