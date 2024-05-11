using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicTrackerModelLibrary
{
    public class Nurses
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
        public string Specialization { get; set; }
        public double Experience { get; set; }

        public Nurses()
        {
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            DateOfBirth = new DateTime();
            Specialization = string.Empty;
            Experience = 0;
        }
        public Nurses(int id, string name, string gender, DateTime dateOfBirth, string specialization, int experience)
        {
            Id = id;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
            Experience = experience;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
        }
    }
}
