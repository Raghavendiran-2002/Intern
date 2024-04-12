
namespace Application
{
    internal class Program
    {
        Doctor CreateDoctorByTakingDetailsFromConsole(int id)
        {
            Doctor doctor = new Doctor(id);
            Console.WriteLine("Name: ");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Age : ");
            int validateAge;
            while(!int.TryParse(Console.ReadLine(), out validateAge)) {
                Console.WriteLine("Age should be number!!!");
            }
            doctor.Age =validateAge;

            int validateExperience;
            Console.WriteLine("Experience : ");
            while (!int.TryParse(Console.ReadLine(), out validateExperience))
            {
                Console.WriteLine("Experience should be number!!!");
            }
            doctor.Experience = validateExperience;

            Console.WriteLine("Qualification : ");
            doctor.Qualification = Console.ReadLine();
            Console.WriteLine("Speciality : ");
            doctor.Speciality = Console.ReadLine();
            return doctor;
        }

        static void Main(string[] args)
        {
            
           
            Program program = new Program();
            Doctor[] doctors = new Doctor[3];
            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"Doctor {i+1}");
                doctors[i] = program.CreateDoctorByTakingDetailsFromConsole(101 + i);
            }
            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"Doctor {i + 1}");
                doctors[i].PrintDoctorDetails();
            }
        }
    }
}
