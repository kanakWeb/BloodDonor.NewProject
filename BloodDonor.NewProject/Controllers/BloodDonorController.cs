using AutoMapper;
using BloodDonor.NewProject.Data;
using BloodDonor.NewProject.Models;
using BloodDonor.NewProject.Models.Entities;
using BloodDonor.NewProject.Models.ViewModel;
using BloodDonor.NewProject.Repositories.Interfaces;
using BloodDonor.NewProject.Services.Interfaces;
using BloodDonor.NewProject.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BloodDonor.NewProject.Controllers
{
    [Authorize]
    public class BloodDonorController : Controller 
    {
      
        private readonly IFileService _fileService;
        private readonly IBloodDonorService _bloodDonorService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public  BloodDonorController(
            IMapper mapper,
            IFileService fileService, 
            IBloodDonorService bloodDonorService,
             IConfiguration configuration)
        {
           
            _fileService = fileService;
            _bloodDonorService = bloodDonorService;
            _mapper= mapper;
            _configuration = configuration;
        }

     
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromQuery]FilterDonorModel filter)
        {
            var dbconectionString = _configuration.GetConnectionString("DefaultConnection");
            var donors = await _bloodDonorService.GetFilteredDonorsAsync(filter);
            var donorViewModels = _mapper.Map<List<BloodDonorListViewModel>>(donors);
            return View(donorViewModels);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(BloodDonorCreateViewModel donor)
        {
            if (!ModelState.IsValid)
                return View(donor);

            var donorEntity = _mapper.Map<BloodDonorEntity>(donor);
            donorEntity.ProfilePicture = await _fileService.SaveFileAsync(donor.ProfilePicture);
            await _bloodDonorService.AddAsync(donorEntity);
            return RedirectToAction("Index");
         }
          

        //details
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var donor=await _bloodDonorService.GetDonorByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
          

           var donorViewModel = _mapper.Map<BloodDonorListViewModel>(donor);
            return View(donorViewModel);
        }


       // edit get method
        public async Task<IActionResult> Edit(int id)
        {
            var donor = await _bloodDonorService.GetDonorByIdAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewMoel = _mapper.Map<BloodDonorEditViewModel>(donor);


            return View(donorViewMoel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BloodDonorEditViewModel donor)
        {
            if (!ModelState.IsValid)

                return View(donor);
          
            var donorEntity = _mapper.Map<BloodDonorEntity>(donor);
            donorEntity.ProfilePicture = await _fileService.SaveFileAsync(donor.ProfilePicture) ?? donor.ExistingProfilePicture;
            await _bloodDonorService.UpdateAsync(donorEntity);
            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var donor =await _bloodDonorService.GetDonorByIdAsync(id);
            if (donor == null)
            {
                return NotFound();

            }
            var donorView =_mapper.Map<BloodDonorListViewModel>(donor);

            return View(donorView);
        }
        [ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
           await _bloodDonorService.DeleteAsync(id);
            return  RedirectToAction("Index");


        }
    }
}
