using System.ComponentModel.DataAnnotations;

namespace BloodDonor.NewProject.Configuration
{
    public class EmailSettings
    {
        [Required]
        public string SmtpServer { get; set; } = string.Empty;
        public int Port { get; set; } = 587;
        
    }
}
