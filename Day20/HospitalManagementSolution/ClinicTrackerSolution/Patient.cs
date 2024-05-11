using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class Patient
    {
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }

        public string MajorDisease { get; set; }

        public Patient()
        {
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            DateOfBirth = new DateTime();
            MajorDisease = string.Empty;
        }
        public Patient(int id, string name,string gender, DateTime dateOfBirth, string Majordisease)
        {
            Id = id;
            Name = name;
            Gender = Gender;
            DateOfBirth = dateOfBirth;
            MajorDisease = Majordisease;
        }
    }
}
