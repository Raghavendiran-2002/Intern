using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModelLibrary
{
    public class Appointment
    {
       
        public int Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int PatientId {  get; set; }
        public int DoctorId { get; set; }
        public int AppointmentNumber { get; set; }
        public Appointment( string reason, int patId, int docId, int appNo)
        {
            Reason = reason; 
            PatientId = patId;
            AppointmentNumber = appNo;
            DoctorId = docId;
        }
    }
}
