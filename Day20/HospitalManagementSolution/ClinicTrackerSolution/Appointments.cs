using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class Appointments
    {
        public int Id { get; set; }
        int age;
        DateTime dob;
        public string PatientName { get; set; }
        public string PatientDisease { get; set; }
        public string PatientGender { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public string AppointmentToDoctor { get; set; }

        public DateTime AppointmentDate { get; set; }

        public Appointments()
        {
            Id = 0;
            PatientName = string.Empty;
            PatientDisease = string.Empty;
            PatientGender = string.Empty;
            DateOfBirth = new DateTime();
            AppointmentToDoctor = string.Empty;
            AppointmentDate = new DateTime();
        }

        public Appointments(int id, string Patientname, string Patientdisease, string Patientgender, DateTime dateOfBirth, string Appointmenttodoctor, DateTime Appointmentdate)
        {
            Id = id;
            PatientName = Patientname;
            PatientDisease = Patientdisease;
            PatientGender = Patientgender;
            DateOfBirth = dateOfBirth;
            AppointmentToDoctor = Appointmenttodoctor;
            AppointmentDate = Appointmentdate;
        }
    }
}
