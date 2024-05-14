using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Context
{
    public class ClinicTrackerContext : DbContext
    {
        public ClinicTrackerContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Pranav", Age = 32, DateOfBirth = new DateTime(2000,05,12),Gender = "Male", Specialization = "Dentist", Experience= 5.5f },
                new Doctor() { Id = 102, Name = "Tharun", Age = 51, DateOfBirth = new DateTime(1954, 05, 12), Gender = "Male", Specialization = "Sergeon", Experience = 2.0f },
                new Doctor() { Id = 103, Name = "Raj", Age = 65, DateOfBirth = new DateTime(2000, 05, 12), Gender = "Male", Specialization = "Dentist", Experience = 7.5f },
                new Doctor() { Id = 104, Name = "Tom", Age = 73, DateOfBirth = new DateTime(1954, 05, 12), Gender = "FeMale", Specialization = "Sergeon", Experience = 23.0f },
                new Doctor() { Id = 105, Name = "Seyon", Age = 42, DateOfBirth = new DateTime(2000, 05, 12), Gender = "Male", Specialization = "Dentist", Experience = 1.5f },
                new Doctor() { Id = 106, Name = "Joe", Age = 76, DateOfBirth = new DateTime(1954, 05, 12), Gender = "FeMale", Specialization = "Dermatologist", Experience = 73.0f }
                );
        }
    }
}
