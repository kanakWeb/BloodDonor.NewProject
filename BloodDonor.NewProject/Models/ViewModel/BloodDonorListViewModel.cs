using System.ComponentModel.DataAnnotations;

namespace BloodDonor.NewProject.Models.ViewModel
{
    public class BloodDonorListViewModel
    {
       public int? Id { get; set; }
        public  string? FullName { get; set; }
        [Phone]
        [Length(10, 15)]
        public required string ContactNumber { get; set; }
        public required int Age { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string BloodGroup { get; set; }
        public required string LastDonationDate { get; set; }
        public string? Address { get; set; }
        public string? ProfilePicture { get; set; }
        public bool IsEligible { get; set; }

    }
}
