using BloodDonor.NewProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.NewProject.Data
{
    public class BloodDonorDbContext : DbContext
    {

        public BloodDonorDbContext(DbContextOptions<BloodDonorDbContext> options) : base(options)
        {

        }

        public DbSet<BloodDonorEntity> BloodDonors { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BloodDonorEntity>()
                .HasData(new BloodDonorEntity
                {
                    Id = 1, // Ensure this ID is unique and not conflicting with existing data
                    FullName = "John Doe",
                    ContactNumber = "1234567890",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "John@gmail.com",
                    Weight=65,
                    Address="Nepal",
                    LastDonationDate = new DateTime(2023, 10, 1),
                    BloodGroup = BloodGroup.APositive,

                },
                new BloodDonorEntity
                {
                    Id = 2, // Ensure this ID is unique and not conflicting with existing data
                    FullName = "Jane Smith",
                    ContactNumber = "0987654321",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Email = "Jane@gmail.com",
                    Weight = 68,
                    Address = "Pakistan",
                    LastDonationDate = new DateTime(2024, 10, 1),
                    BloodGroup = BloodGroup.BNegative,

                }); // Initial data seeding can be done here if needed
          }      
    }
}
