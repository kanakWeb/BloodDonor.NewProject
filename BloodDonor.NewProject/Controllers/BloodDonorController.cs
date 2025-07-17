using BloodDonor.Models;
using BloodDonor.NewProject.Data;
using BloodDonor.NewProject.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BloodDonor.NewProject.Controllers
{
   
    public class BloodDonorController : Controller 
    {
        private readonly BloodDonorDbContext _context;
        private readonly IWebHostEnvironment _env;


        public  BloodDonorController(BloodDonorDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(string bloodGroup, string address)
        {
            IQueryable<BloodDonorEntity> query = _context.BloodDonors;

            if (!string.IsNullOrEmpty(bloodGroup))
                query = query.Where(d => d.BloodGroup.ToString() == bloodGroup);

           if(!string.IsNullOrEmpty(address))
                query = query.Where(d => d.Address != null && d.Address.Contains(address));

                var donors =query.ToList();
                return View(donors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(BloodDonorCreateViewModel donor)
        {
            if (!ModelState.IsValid) 
            
                return View();
            
            var donorEntity= new BloodDonorEntity
            {
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                DateOfBirth = donor.DateOfBirth,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup,
                Weight = donor.Weight,
                LastDonationDate = donor.LastDonationDate,
                Address = donor.Address,
                //ProfilePicture = donor.ProfilePicture?.FileName // Assuming you want to store the file name

            };

            if (donor.ProfilePicture != null && donor.ProfilePicture.Length > 0)
            {
                var  fileName=$"{Guid.NewGuid()}{Path.GetExtension(donor.ProfilePicture.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, "profiles");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }                                                           

                var fullPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(fullPath,FileMode.Create))
                {
                    await donor.ProfilePicture.CopyToAsync(stream);
                }

                donorEntity.ProfilePicture =Path.Combine("profiles", fileName); // Store the relative path to the profile picture   
            }
                _context.BloodDonors.Add(donorEntity);
                 _context.SaveChanges();
                return RedirectToAction("Index");
            }
          
        
    }
}
