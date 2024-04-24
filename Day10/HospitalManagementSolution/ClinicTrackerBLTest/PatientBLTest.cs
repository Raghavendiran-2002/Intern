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
    public class PatientBLTest
    {
        IRepository<int, Patient> repository;
        IPatientService patientService;
        [SetUp]
        public void Setup()
        {
            repository = new PatientRepository();
            Patient patient = new Patient() { Name = "Arulselvi",MajorDisease = "BP" };
            repository.Add(patient);
            patientService = new PatientBusinessLogic(repository);
        }
        [Test]
        public void ChangePatientNameSuccess()
        {
            var patient = patientService.ChangePatientName(1, "Raghav");
            Assert.AreEqual(1, patient.Id);
        }
        [Test]
        public void ChangePatientnameFail()
        {
            var patient = patientService.ChangePatientName(2, "Pranav");
            Assert.AreNotEqual(1, patient.Id);
        }
        [Test]
        public void ChangePatientNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientService.ChangePatientName(2, "Ragul"));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void ChangePatientDiseaseSuccess()
        {
            var patient = patientService.ChangeMajorDisease(1, "Pressure");
            Assert.AreEqual(1, patient.Id);
        }
        [Test]
        public void ChangePatientDiseaseFail ()
        {
            var patient = patientService.ChangeMajorDisease(2, "Pressure");
            Assert.AreNotEqual(1, patient.Id);
        }
        [Test]
        public void ChangePatientDiseaseExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientService.ChangeMajorDisease(2, "Pressure"));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void DeletePatientSuccess()
        {
            var patient = patientService.DeletePatients(1);
            Assert.AreEqual(1, patient.Id);
        }
        [Test]
        public void DeletePatientFail()
        {
            var patient = patientService.DeletePatients(2);
            Assert.AreEqual(1, patient.Id);
        }
        [Test]
        public void DeletePatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException> (() => patientService.DeletePatients(2));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void GetPatientbyIDSuccess()
        {
            var patient = patientService.GetPatient(1);
            Assert.AreEqual(1, patient.Id);
        }
        [Test]
        public void GetPatientbyIDFailure()
        {
            var patient = patientService.GetPatient(2);
            Assert.AreEqual(1, patient.Id);
        }
        [Test]
        public void GetPatientByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientNotFoundException>(() => patientService.GetPatient(2));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }

    }
}
