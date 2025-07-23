using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonor.NewProject.Models.Entities
{
    public class Donation : BaseEntity
    {
        
        public DateTime DonationDate { get; set; }
        [ForeignKey("BloodDonor")]
        public int BloodDonorId { get; set; }

    }
}
