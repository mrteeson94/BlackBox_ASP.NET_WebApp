using System.ComponentModel.DataAnnotations;

namespace blackBox.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driver License")]
        public string DriverLicense { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
