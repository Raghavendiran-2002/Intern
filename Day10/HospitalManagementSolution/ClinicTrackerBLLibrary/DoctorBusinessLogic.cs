using ClinicTrackerBLLibrary;
using ClinicTrackerDALLibrary;
using ClinicTrackerModelLibrary;
using System.Diagnostics.CodeAnalysis;
namespace ClinicAppointmentBLLibrary
{
    public class DoctorBusinessLogic : IDoctorsService
    {
        readonly IRepository<int, Doctor> _doctorRepository;
        public DoctorBusinessLogic(IRepository<int, Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [ExcludeFromCodeCoverage]
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = _doctorRepository.Add(doctor);
            if (result != null)
            {
                return result;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor ChangeDoctorExperience(int id, double newExperience)
        {
            Doctor doctor= _doctorRepository.Get(id);
            if (doctor != null)
            {
                doctor.Experience = newExperience;
                _doctorRepository.Update(doctor);
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor ChangeDoctorName(int id, string NewDoctorName)
        {
            Doctor doctor = _doctorRepository.Get(id);
            if (doctor != null)
            {
                doctor.Name= NewDoctorName;
                _doctorRepository.Update(doctor);
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor ChangeDoctorSpecialization(int id, string NewSpecialization)
        {
            Doctor doctor = _doctorRepository.Get(id);
            if (doctor != null)
            {
                doctor.Specialization = NewSpecialization;
                _doctorRepository.Update(doctor);
                return doctor;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor DeleteDoctor(int id)
        {
            var result = _doctorRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new DoctorNotFoundException();
        }

        public Doctor GetDoctorById(int id)
        {
            Doctor doctor = _doctorRepository.Get(id);
            if (doctor != null)
            {
                return doctor;
            }
            throw new DoctorNotFoundException();
        }
    }
}