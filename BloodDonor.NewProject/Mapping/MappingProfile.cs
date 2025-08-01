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
            .ForMember(dest => dest.IsEligible, opt => opt.MapFrom(src => BloodDonorService.IsEligible(src)))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateHelper.CalculateAge(src.DateOfBirth)));

            CreateMap<BloodDonorCreateViewModel, BloodDonorEntity>();
            CreateMap<BloodDonorEditViewModel, BloodDonorEntity>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.Ignore())
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ExistingProfilePicture));

            CreateMap<BloodDonorEntity ,BloodDonorEditViewModel>()
            .ForMember(dest => dest.ProfilePicture, opt => opt.Ignore())
            .ForMember(des=>des.ExistingProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture)); 


        }

    }   
}
