using BloodDonor.NewProject.Models.Entities;
using System.Linq.Expressions;

namespace BloodDonor.NewProject.Repositories.Interfaces
{
    public interface IRepository<T>where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetDonorByIdAsync(int? id);
        void Add(T donor);
        void Update(T donor);
        void Delete(T donor);
    }
}
