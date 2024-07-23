using MedicalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Doctor>().ToTable("Doctors", "DC");
        }
        public DbSet<MedicalSpecialities> specialities { get; set; }
        public DbSet<Doctor> doctors { get; set; }
    }
}
