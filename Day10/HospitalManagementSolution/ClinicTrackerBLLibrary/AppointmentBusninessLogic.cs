using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public class AppointmentBusninessLogic : IAppointmentService
    {
        readonly IRepository<int, Appointments> _AppointmentRepository;
        public AppointmentBusninessLogic(IRepository<int, Appointments> appointmentRepository)
        {
            _AppointmentRepository = appointmentRepository;
        }
        [ExcludeFromCodeCoverage]
        public Appointments AddAppointment(Appointments appointments)
        {
            var result = _AppointmentRepository.Add(appointments);
            if (result != null)
            {
                return result;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointments ChangeAppointmentDate(int id, DateTime date)
        {
            Appointments appointment = _AppointmentRepository.Get(id);
            if (appointment != null)
            {
                appointment.AppointmentDate = date;
                _AppointmentRepository.Update(appointment);
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointments ChangeAppointmenttoDoctors(int id, string NewDoctorName)
        {
            Appointments appointment = _AppointmentRepository.Get(id);
            if (appointment != null)
            {
                appointment.AppointmentToDoctor = NewDoctorName;
                _AppointmentRepository.Update(appointment);
                return appointment;
            }
            throw new AppointmentNotFoundException();
        }

        public Appointments DeleteAppointments(int id)
        {
            var result = _AppointmentRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new AppointmentNotFoundException();
        }       
    }
}
