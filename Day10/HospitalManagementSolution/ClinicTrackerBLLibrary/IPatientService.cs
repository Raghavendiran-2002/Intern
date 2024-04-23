using ClinicTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerBLLibrary
{
    public interface IPatientService
    {
        Patient AddPatient(Patient patient);
        Patient GetPatient(int id);
        Patient ChangePatientName(int id, string NewName);
        Patient ChangeMajorDisease(int id, string NewDisease);
        Patient DeletePatients(int id);

    }
}
