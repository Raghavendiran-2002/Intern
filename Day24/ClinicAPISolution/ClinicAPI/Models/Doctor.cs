namespace ClinicAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Specialization { get; set; }
        public float Experience { get; set; }

    }
}
