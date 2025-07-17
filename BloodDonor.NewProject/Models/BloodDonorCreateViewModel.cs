using BloodDonor.Models;
using System.ComponentModel.DataAnnotations;

namespace BloodDonor.NewProject.Models
{
    public class BloodDonorCreateViewModel
    {
        public required string FullName { get; set; }
        [Phone]
        [Length(10, 15)]
        public required string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required BloodGroup BloodGroup { get; set; }


        [Range(50, 150, ErrorMessage = "Age must be between 50 and 150 years.")]
        [Display(Name = "Weight (kg)")]
        public float Weight { get; set; }
        public DateTime? LastDonationDate { get; set; }

        // Additional properties can be added as needed
        public string? Address { get; set; }

        public IFormFile? ProfilePicture { get; set; }
    }
}
