using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;

namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int, Doctor> _repository;
        public DoctorService(IRepository<int , Doctor> repository) {
            _repository = repository;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _repository.Get();
            if (doctors.Count() == 0)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBasedOnSpeciality(string specialization)
        {
            var doctors = (await _repository.Get()).Where(d => d.Specialization == specialization);
            if (doctors == null)
                throw new NoDoctorsFoundException();
            return doctors;
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, float experience)
        {
            var doctor = await _repository.Get(id);
            if(doctor == null)
                throw new NoSuchDoctorException ();
            doctor.Experience = experience;
            doctor = await _repository.Update(doctor);
            return doctor;
        }
    }
}
