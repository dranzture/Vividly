using System.ComponentModel.DataAnnotations;

namespace Vividly.View_Models.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }

}