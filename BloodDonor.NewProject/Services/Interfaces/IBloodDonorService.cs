using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Models.ViewModel;
using BloodDonor.NewProject.Services.Model;


namespace BloodDonor.NewProject.Services.Interfaces
{
    public interface IBloodDonorService
    {
        Task<IEnumerable<BloodDonorEntity>> GetAllDonorsAsync();
        Task<List<BloodDonorEntity>> GetFilteredDonorsAsync(FilterDonorModel filter);
        Task<BloodDonorEntity?> GetDonorByIdAsync(int id);
        Task AddAsync(BloodDonorEntity donor);
        Task UpdateAsync(BloodDonorEntity donor);
        Task DeleteAsync(int id);
   
    }
}
