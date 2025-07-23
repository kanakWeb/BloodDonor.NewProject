using AutoMapper;
using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Models.ViewModel;
using BloodDonor.NewProject.Services.Implementataions;
using BloodDonor.NewProject.Services.Model;
using BloodDonor.NewProject.Utilities;
using System.Drawing;

namespace BloodDonor.NewProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BloodDonorEntity, BloodDonorListViewModel>()
            .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => src.BloodGroup.ToString()))
            .ForMember(dest => dest.LastDonationDate, opt => opt.MapFrom(src => DateHelper.GetLastDonationDateString(src.LastDonationDate)))
            .ForMember(dest => dest.IsEligible, opt => opt.MapFrom(src => BloodDonorService.IsEliglible(src)))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateHelper.CalculateAge(src.DateOfBirth)));

            CreateMap<BloodDonorCreateViewModel, BloodDonorEntity>();
            CreateMap<BloodDonorEditViewModel, BloodDonorEntity>();
            CreateMap<BloodDonorEntity ,BloodDonorEditViewModel>()
            .ForMember(des=>des.ExistingProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture)); 


        }

    }   
}
