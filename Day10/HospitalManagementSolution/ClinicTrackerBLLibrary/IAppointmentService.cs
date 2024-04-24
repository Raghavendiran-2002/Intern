using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public interface IAppointmentService
    {
        Appointments AddAppointment(Appointments appointments);
        Appointments ChangeAppointmentDate(int id, DateTime date);
        Appointments ChangeAppointmenttoDoctors(int id, string NewDoctorName);
       
        Appointments DeleteAppointments(int id);

    }
}
