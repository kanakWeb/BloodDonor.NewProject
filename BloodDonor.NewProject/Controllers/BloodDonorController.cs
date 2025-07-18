using BloodDonor.Models;
using BloodDonor.NewProject.Data;
using BloodDonor.NewProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
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

        public IActionResult Index(string bloodGroup, string address, bool? isEligible)
        {
            IQueryable<BloodDonorEntity> query = _context.BloodDonors;

            if (!string.IsNullOrEmpty(bloodGroup))
                query = query.Where(d => d.BloodGroup.ToString() == bloodGroup);

           if(!string.IsNullOrEmpty(address))
                query = query.Where(d => d.Address != null && d.Address.Contains(address));
        
                var donors =query.Select(d=>new BloodDonorListViewModel
                {
                    Id = d.Id ?? 0,
                    FullName = d.FullName ?? "Unknown",
                    ContactNumber = d.ContactNumber,
                    Age = DateTime.Now.Year - d.DateOfBirth.Year,
                    Email = d.Email,
                    BloodGroup = d.BloodGroup.ToString(),
                    LastDonationDate=d.LastDonationDate.HasValue ? $"{(DateTime.Today-d.LastDonationDate.Value).Days} days ago" : "Never",
                    Address = d.Address,
                    ProfilePicture = d.ProfilePicture, // You can set this to the path of the profile picture if needed
                    IsEligible = (d.Weight>45 && d.Weight<200) && (d.LastDonationDate == null || (DateTime.Now - d.LastDonationDate.Value).TotalDays >= 90) // Assuming eligibility is based on last donation date
                }).ToList( );
            if (isEligible.HasValue)
            {
                donors = donors.Where(x => x.IsEligible == isEligible).ToList();
            }
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
          

        //details
        public IActionResult Details(int id)
        {
            var donor=_context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorView = new BloodDonorListViewModel
            {
                
                Id = donor.Id,
                ProfilePicture = donor.ProfilePicture,
                FullName = donor.FullName,
                BloodGroup = donor.BloodGroup.ToString(),
                ContactNumber = donor.ContactNumber,
                Email = donor.Email,
                Address = donor.Address,
                Age = DateTime.Now.Year - donor.DateOfBirth.Year,
                LastDonationDate = donor.LastDonationDate.HasValue ? $"{(DateTime.Today - donor.LastDonationDate.Value).Days}days ago" : "Never",
                IsEligible = (donor.Weight > 45 && donor.Weight < 200) && (donor.LastDonationDate == null || (DateTime.Now - donor.LastDonationDate.Value).TotalDays >= 90)
                
            };

            return View(donorView);
        }


       // edit get method
        public IActionResult Edit(int id)
        {
            var donor = _context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            var EditView = new BloodDonorEditViewModel
            {

                Id = donor.Id,
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                DateOfBirth = donor.DateOfBirth,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup,
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate,
                ExistingProfilePicture = donor.ProfilePicture

            };

            return View(EditView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BloodDonorEditViewModel donor)
        {
            if (!ModelState.IsValid)

                return View(donor);

            var donorEntity = new BloodDonorEntity
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
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(donor.ProfilePicture.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, "profiles");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var fullPath = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await donor.ProfilePicture.CopyToAsync(stream);
                }

                donorEntity.ProfilePicture = Path.Combine("profiles", fileName); // Store the relative path to the profile picture   
            }
            _context.BloodDonors.Add(donorEntity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var donor = _context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();

            }
            var donorView = new BloodDonorListViewModel
            {

                Id = donor.Id,
                ProfilePicture = donor.ProfilePicture,
                FullName = donor.FullName,
                BloodGroup = donor.BloodGroup.ToString(),
                ContactNumber = donor.ContactNumber,
                Email = donor.Email,
                Address = donor.Address,
                Age = DateTime.Now.Year - donor.DateOfBirth.Year,
                LastDonationDate = donor.LastDonationDate.HasValue ? $"{(DateTime.Today - donor.LastDonationDate.Value).Days}days ago" : "Never",
                IsEligible = (donor.Weight > 45 && donor.Weight < 200) && (donor.LastDonationDate == null || (DateTime.Now - donor.LastDonationDate.Value).TotalDays >= 90)

            };

            return View(donorView);
        }
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var donor = _context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();

            }
            _context.BloodDonors.Remove(donor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
