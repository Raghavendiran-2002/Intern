using System.Data;

namespace HospitalModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public Doctor() { Id = int.MaxValue;
            Name = string.Empty;
            Specialization = string.Empty;
        }     
        public Doctor( string name, string specialization)
        {
            Name = name;
            Specialization = specialization;
        }

        public override string ToString()
        {
            return
                "Doctor Id : " + Id
             + "\n Name " + Name
             + "\nDoctor Age : " + Specialization;
        }

    }
}
