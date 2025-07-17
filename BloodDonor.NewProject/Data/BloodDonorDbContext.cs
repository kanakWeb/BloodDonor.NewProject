using BloodDonor.Models;
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

        
    }
    

    
}
