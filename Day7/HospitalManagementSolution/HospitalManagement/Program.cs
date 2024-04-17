using HospitalDALLibrary;

namespace HospitalManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoctorRepository d  = new DoctorRepository();
            d.Add(new HospitalModelLibrary.Doctor( "Tharun", "hdsg"));
            Console.WriteLine("runninggngngn");
            Console.WriteLine(d.Get(1));
            d.GetAll();
        }
    }
}
