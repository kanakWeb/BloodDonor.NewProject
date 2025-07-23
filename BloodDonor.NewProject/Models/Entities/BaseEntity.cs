using System.ComponentModel.DataAnnotations;

namespace BloodDonor.NewProject.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int? Id { get; set; }
    }
}
