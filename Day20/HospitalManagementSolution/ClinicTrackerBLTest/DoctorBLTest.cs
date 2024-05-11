using ClinicAppointmentBLLibrary;
using ClinicTrackerBLLibrary;
using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;

namespace ClinicTrackerBLTest
{
    public class DoctorBLTest
    {
        IRepository<int, Doctor> repository;
        IDoctorsService doctorService;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            Doctor doctor = new Doctor() { Name = "IT", Experience = 10 };
            repository.Add(doctor);
            doctorService = new DoctorBusinessLogic(repository);
        }

        [Test]
        public void ChangeDoctorExperienceSuccess()
        {
            var doctor = doctorService.ChangeDoctorExperience(1,12);
            Assert.AreEqual(1, doctor.Id);
        }
        [Test]
        public void ChangeDoctorExperienceFail()
        {
            var doctor= doctorService.ChangeDoctorExperience(2, 12);
            Assert.AreNotEqual(1, doctor.Id);
        }
        [Test]
        public void ChangeDoctorExperienceExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.ChangeDoctorExperience(2,11));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void ChangeDoctorNameSuccess()
        {
            var doctor = doctorService.ChangeDoctorName(1, "Sanjai");
            Assert.AreEqual(1, doctor.Id);
        }
        [Test]
        public void ChangeDoctorNameFail()
        {
            var doctor = doctorService.ChangeDoctorName(2, "sanjai");
            Assert.AreNotEqual(1, doctor.Id);
        }
        [Test]
        public void ChangeDoctorNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.ChangeDoctorName(2, "sanjai"));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void ChangeDoctorSpecializationSuccess()
        {
            var doctor = doctorService.ChangeDoctorSpecialization(1, "Heart");
            Assert.AreEqual(1, doctor.Id);
        }
        [Test]
        public void ChangeDoctorSpecializationFail()
        {
            var doctor = doctorService.ChangeDoctorSpecialization(2, "Heart");
            Assert.AreNotEqual(1, doctor.Id);
        }
        [Test]
        public void ChangeDoctorSpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.ChangeDoctorSpecialization(2, "Heart"));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void DeleteDoctorSuccess()
        {
            var doctor = doctorService.DeleteDoctor(1);
            Assert.AreEqual(1, doctor.Id);
        }
        [Test]
        public void DeleteDoctorFail()
        {
            var doctor = doctorService.DeleteDoctor(2);
            Assert.AreNotEqual(1, doctor.Id);
        }
        [Test]
        public void DeleteDoctorExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.DeleteDoctor(2));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
        [Test]
        public void GetDoctorbyIDSuccess()
        {
            var doctor = doctorService.GetDoctorById(1);
            Assert.AreEqual(1, doctor.Id);
        }
        [Test]
        public void GetDoctorbyIDFail()
        {
            var doctor = doctorService.GetDoctorById(2);
            Assert.AreNotEqual(1, doctor.Id);
        }
        [Test]
        public void GetDoctorByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorNotFoundException>(() => doctorService.GetDoctorById(2));
            //Assert
            Assert.AreEqual("The method or operation is not implemented.", exception.Message);
        }
    }
}