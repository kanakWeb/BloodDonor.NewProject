using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Repositories.Interfaces;

namespace BloodDonor.NewProject.Repositories.Implementations
{
    public class DonationRepository : IDonationRepository
    {
        public void Add(Donation donor)
        {
            throw new NotImplementedException();
        }

        public void Delete(Donation donor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Donation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Donation?> GetDonorByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Donation donor)
        {
            throw new NotImplementedException();
        }
    }
}
