using BloodDonor.Models;
using BloodDonor.NewProject.Data;
using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BloodDonor.NewProject.Repositories.Implementations
{
    public class BloodDonorRepository : Repository<BloodDonorEntity>, IBloodDonorRepository
    {
        public BloodDonorRepository(BloodDonorDbContext context) : base(context)
        {
        }
    }
}
