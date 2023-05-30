using System.ComponentModel.DataAnnotations;

namespace blackBox.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Driver License")]
        [StringLength(255)]
        public string DriverLicense { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
