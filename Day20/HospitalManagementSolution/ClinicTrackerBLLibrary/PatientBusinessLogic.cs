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
    public class PatientBusinessLogic : IPatientService
    {
        readonly IRepository<int, Patient> _patientRepository;
        public PatientBusinessLogic(IRepository<int, Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [ExcludeFromCodeCoverage]
        public Patient AddPatient(Patient patient)
        { 
            var result = _patientRepository.Add(patient);
            if (result != null)
            {
                return result;
            }
            throw new PatientNotFoundException();
        }

        public Patient ChangeMajorDisease(int id, string NewDisease)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient != null)
            {
                patient.MajorDisease = NewDisease;
                _patientRepository.Update(patient);
                return patient;
            }
            throw new PatientNotFoundException();
        }

        public Patient ChangePatientName(int id,string NewName)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient != null)
            {
                patient.Name = NewName;
                _patientRepository.Update(patient);
                return patient;
            }
            throw new PatientNotFoundException();
        }


        public Patient DeletePatients(int id)
        {
            var result = _patientRepository.Delete(id);
            if (result != null)
            {
                return result;
            }
            throw new PatientNotFoundException();
        }

        public Patient GetPatient(int id)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient != null)
            {
                return patient;
            }
            throw new PatientNotFoundException();
        }

        
    }
}
