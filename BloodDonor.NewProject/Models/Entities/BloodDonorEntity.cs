using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonor.NewProject.Models.Entities
{
    public class BloodDonorEntity : BaseEntity
    {
       
        public required string FullName { get; set; }
        [Phone]
        [Length(10,15)]
        public required string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required BloodGroup BloodGroup { get; set; }
        [Range(45, 200, ErrorMessage = "Age must be between 45 and 200 years.")]
        [Display(Name ="Weight (kg)")]
        public float Weight { get; set; }
        public DateTime? LastDonationDate { get; set; }
        
        // Additional properties can be added as needed
        public string? Address { get; set; }

        public string? ProfilePicture { get; set; }
      

       public Collection<Donation> Donations { get; set; } = new Collection<Donation>();
       
    }


}

