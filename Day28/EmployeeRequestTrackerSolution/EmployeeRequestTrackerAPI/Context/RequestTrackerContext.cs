using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeRequestTrackerAPI.Context
{
    public class RequestTrackerContext : DbContext
    {

        // Add-Migration Init
        // Update-Database
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Request>().HasOne(r=>r.RequestRaisedByEmployee).WithMany(e=> e.RequestsRaised).HasForeignKey(r =>r.RequestRaisedBy).OnDelete(DeleteBehavior.Restrict).IsRequired();

            modelBuilder.Entity<Request>().HasOne(r => r.RequestClosedByEmployee).WithMany(e => e.RequestsClosed).HasForeignKey(r => r.RequestClosedBy).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
