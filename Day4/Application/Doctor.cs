using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }
        public Doctor(int id)
        {
            Id = id;    
        }
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="exp"></param>
        /// <param name="qual"></param>
        /// <param name="spec"></param>
        public Doctor(int id, string name, int age, int exp, string qual, string spec)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = exp;   
            Qualification = qual;   
            Speciality = spec;  

        }
        /// <summary>
        /// Prints all Details of the Doctor
        /// </summary>
        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Id\t:\t{Id}");
            Console.WriteLine($"Name\t:\t{Name}");

            Console.WriteLine($"Age\t:\t{Age}");

            Console.WriteLine($"Experience\t:\t{Experience}");

            Console.WriteLine($"Qualification\t:\t{Qualification}");

            Console.WriteLine($"Speciality\t:\t{Speciality}");

        }

    }
}
