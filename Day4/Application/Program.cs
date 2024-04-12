namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Doctor doctor = new Doctor(1, "Ram", 23,2,"MBBS","Hematologists");
            doctor.PrintDoctorDetails();
        }
    }
}
