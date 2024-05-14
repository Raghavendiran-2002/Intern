using ClinicAPI.Context;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Models.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicTrackerContext _context;
        public DoctorRepository(ClinicTrackerContext context)
        {
            _context  = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var doctor = await Get(key);
            if(doctor != null)
            {
                _context.Remove(doctor);
                await _context.SaveChangesAsync();
            }
            throw new NoSuchDoctorException();
        }

        public async Task<Doctor> Get(int key)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(e => e.Id == key);
            if(doctor != null)
                return doctor;
            throw new NoSuchDoctorException();
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = await _context.Doctors.ToListAsync();
            if (doctors.Count != 0)
                return doctors;
            throw new NoSuchDoctorException();
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var doctor = await Get(item.Id);
            if(doctor != null)
            {
                _context.Update(item);
               await _context.SaveChangesAsync(); 
                return doctor;
            }
            throw new NoSuchDoctorException();
        }
    }
}
