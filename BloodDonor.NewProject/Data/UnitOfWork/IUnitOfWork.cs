using BloodDonor.NewProject.Repositories.Interfaces;

namespace BloodDonor.NewProject.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    { 
        IBloodDonorRepository BloodDonorRepository { get; }
        IDonationRepository DonationRepository { get; }
        Task<int> SaveAsync();
    }
}
