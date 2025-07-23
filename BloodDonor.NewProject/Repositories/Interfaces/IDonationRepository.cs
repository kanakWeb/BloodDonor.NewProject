using BloodDonor.NewProject.Models.Entities;
using System.Linq.Expressions;

namespace BloodDonor.NewProject.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation?> GetDonorByIdAsync(int? id);
        void Add(Donation donor);
        void Update(Donation donor);
        void Delete(Donation donor);
    }
}

