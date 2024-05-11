using System;
using System.Collections.Generic;

namespace ClinicTracker.Model
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Disease { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AppointmentToDoctor { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
