using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonor.Models
{
    public class BloodDonorEntity
    {
        [Key]
       public int? Id { get; set; }
        public string? FullName { get; set; }
        [Phone]
        [Length(10,15)]
        public required string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required BloodGroup BloodGroup { get; set; }
        [Range(45, 200, ErrorMessage = "Age must be between 50 and 150 years.")]
        [Display(Name ="Weight (kg)")]
        public float Weight { get; set; }
        public DateTime? LastDonationDate { get; set; }
        
        // Additional properties can be added as needed
        public string? Address { get; set; }

        public string? ProfilePicture { get; set; }
      

       public Collection<Donation> Donations { get; set; } = new Collection<Donation>();
       
    }

    public enum BloodGroup
    {
        APositive,
        ANegative,
        BPositive,
        BNegative,
        ABPositive,
        ABNegative,
        OPositive,
        ONegative
    }
    public class Donation
    {
        public int Id { get; set; }
        public DateTime DonationDate { get; set; }
        [ForeignKey("BloodDonor")]
        public int BloodDonorId { get; set; }

    }

}

