using System.Linq.Expressions;

namespace ClinicTrackerModelLibrary

{
    public class Doctor
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

        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Gender = string.Empty;
            DateOfBirth = new DateTime();
            Specialization = string.Empty;
            Experience = 0;
        }
        public Doctor(int id, string name,string gender, DateTime dateOfBirth, string specialization,int experience)
        {
            Id = id;
            Name = name;
            Gender = Gender;
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