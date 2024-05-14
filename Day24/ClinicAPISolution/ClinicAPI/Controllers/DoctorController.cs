using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors.ToList());
            }
            catch (NoDoctorsFoundException ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Doctor>> Put(int id, float experienc)
        {
            try {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experienc);
                return Ok(doctor);
            }
            catch (NoSuchDoctorException ex) {
                return NotFound(ex.Message);
            }
        }
        [Route("Speciality")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get(string spec) {
            try
            {
                var doctors = await _doctorService.GetDoctorsBasedOnSpeciality(spec);
                return Ok(doctors);
            }
            catch(NoDoctorsFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
            
            

