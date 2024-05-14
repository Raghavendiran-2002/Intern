using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetDoctors();
        public Task<Doctor> UpdateDoctorExperience(int id, float experience);
        public Task<IEnumerable<Doctor>> GetDoctorsBasedOnSpeciality(string specialization);

    }
}
