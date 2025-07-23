using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonor.NewProject.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
           
            _dbSet = context.Set<T>();
        }
        public void Add(T donor)
        {
            _dbSet.Add(donor);
        }

        public void Delete(T donor)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
          return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetDonorByIdAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T donor)
        {
            _dbSet.Update(donor);
        }
 
    }
}
