using BloodDonor.NewProject.Data.UnitOfWork;
using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Models.ViewModel;
using BloodDonor.NewProject.Repositories.Interfaces;
using BloodDonor.NewProject.Services.Interfaces;
using BloodDonor.NewProject.Services.Model;
using BloodDonor.NewProject.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BloodDonor.NewProject.Services.Implementataions
{
    public class BloodDonorService : IBloodDonorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodDonorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(BloodDonorEntity donor)
        {
            _unitOfWork.BloodDonorRepository.Add(donor);
             await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var donor = await _unitOfWork.BloodDonorRepository.GetDonorByIdAsync(id);
            if (donor != null)
            {
                _unitOfWork.BloodDonorRepository.Delete(donor);
                await _unitOfWork.SaveAsync();
            
            }
            
        }

     
        public Task<IEnumerable<BloodDonorEntity>> GetAllDonorsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BloodDonorEntity?> GetDonorByIdAsync(int id)
        {
            return await _unitOfWork.BloodDonorRepository.GetDonorByIdAsync(id);
        }

        public async Task<List<BloodDonorEntity>> GetFilteredDonorsAsync(FilterDonorModel filter)
        {
            var query = _unitOfWork.BloodDonorRepository.Query();

            if (!string.IsNullOrEmpty(filter.bloodGroup))
                query = query.Where(d => d.BloodGroup.ToString() == filter.bloodGroup);

            if (!string.IsNullOrEmpty(filter.address))
                query = query.Where(d => d.Address != null && d.Address.Contains(filter.address));

          
            return await query.ToListAsync();
        }

        public Task UpdateAsync(BloodDonorEntity donor)
        {
           _unitOfWork.BloodDonorRepository.Update(donor);
            return _unitOfWork.SaveAsync();
        }
        public static bool IsEligible(BloodDonorEntity donor)
        { 
        
            if (donor.Weight < 45 || donor.Weight > 200)
            {
                return false;
            }

            if(donor.LastDonationDate.HasValue)
            {
                var daysSinceLastDonation = (DateTime.Now - donor.LastDonationDate.Value).TotalDays;
                if (daysSinceLastDonation < 90)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
