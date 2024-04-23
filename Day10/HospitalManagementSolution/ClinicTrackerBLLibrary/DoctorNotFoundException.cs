using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public class DoctorNotFoundException : Exception
    {
        string msg;
        public DoctorNotFoundException()
        {
            msg = "No Doctor Found!";
        }

        public override string Message => msg;
    }
}
