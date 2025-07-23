using BloodDonor.NewProject.Data;
using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BloodDonor.NewProject.Repositories.Implementations
{
    public class BloodDonorRepository : Repository<BloodDonorEntity>, IBloodDonorRepository
    {
        public BloodDonorRepository(DbContext context) : base(context)
        {
        }
    }
}
