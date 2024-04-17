using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModelLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age {  get; set; }
        public string Address { get; set; } = string.Empty;
        public int AppointmentId { get; set; } = int.MaxValue;

        public Patient(string name, int age, string address) {
            Name = name;
            Age = age;
            Address = address;
        }
    }
}
