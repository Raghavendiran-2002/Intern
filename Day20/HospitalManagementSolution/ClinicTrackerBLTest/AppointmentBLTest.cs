using ClinicAppointmentBLLibrary;
using ClinicTrackerBLLibrary;
using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLTest
{
    public class AppointmentBLTest
    {
        IRepository<int, Appointments> repository;
        IAppointmentService appointmentService;
        [SetUp]
        public void Setup()
        {
            repository = new AppointmentRepository();
            Appointments appointment = new Appointments() { PatientName = "sanjai" };
            repository.Add(appointment);
            appointmentService = new AppointmentBusninessLogic(repository);
        }


        [Test]
        public void ChangeAppointmenttoDoctorSuccess()
        {
            var appointment = appointmentService.ChangeAppointmenttoDoctors(1, "Ragul");
            Assert.AreEqual(1, appointment.Id);
        }
        [Test]
        public void ChangeAppointmenttoDoctorFail()
        {
            var appointment = appointmentService.ChangeAppointmenttoDoctors(2, "Ragul");
            Assert.AreNotEqual(1, appointment.Id);
        }
        [Test]
        public void ChangeAppointmenttoDoctorExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentService.ChangeAppointmenttoDoctors(2, "Ragul"));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void ChangeAppointmentDateSuccess()
        {
            var appointment = appointmentService.ChangeAppointmentDate(1, new DateTime(2000, 12, 2));

            Assert.AreEqual(1, appointment.Id);
        }
        [Test]
        public void ChangeAppointmentDateFail()
        {
            var appointment = appointmentService.ChangeAppointmentDate(2, new DateTime(2000, 12, 2));

            Assert.AreNotEqual(1, appointment.Id);
        }
        [Test]
        public void ChangeAppointmentDateExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentService.ChangeAppointmentDate(2, new DateTime(2000, 12, 2)));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void DeleteAppointmentSuccess()
        {
            var doctor = appointmentService.DeleteAppointments(1);
            Assert.AreEqual(1, doctor.Id);
        }
        [Test]
        public void DeleteAppointmentfail()
        {
            var doctor = appointmentService.DeleteAppointments(2);
            Assert.AreNotEqual(1, doctor.Id);
        }
        [Test]
        public void DeleteAppointmentExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => appointmentService.DeleteAppointments(2));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
    }
}
